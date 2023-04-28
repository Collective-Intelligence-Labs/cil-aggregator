using System.Linq.Expressions;
using Cila.Database;
using Cila.Documents;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Cila 
{
    public class InfrastructureEventsHandler: IEventHandler
    {
        private readonly IMongoCollection<OperationDocument> _operations;

        private MongoDatabase _db;
        public InfrastructureEventsHandler(MongoDatabase db)
        {
            _operations = db.GetOperations();
            _db = db;
        }

        public void Handle(InfrastructureEvent e)
        {
            //if (e.EvntType == InfrastructureEventType.ApplicationOperationInitiatedEvent)
            //{
                var doc = _db.FindOne(e.OperationId);
                if (doc == null)
                {
                    doc = new OperationDocument{
                        Id = e.OperationId,
                        Commands = e.Commands.Select(x=> x.Id).ToList(),
                        Created = e.Timestamp.ToDateTime(),
                        ClientID = e.PortalId
                 };
                 _operations.InsertOne(doc);
                };
            //}
            var infEv = CreateNewInfrastructureEvent(e);
       
            var syncItem = new SyncItems {
                Timestamp = e.Timestamp.ToDateTime(),
                OriginalSource = !e.Events.Any(x=> x.Conflict),
                ErrorMessage = e.ErrorMessage 
            };

            switch(e.EvntType)
            {
                case InfrastructureEventType.TransactionRoutedEvent:
                    syncItem.Id = e.RouterId;
                    syncItem.Name = "Router " + syncItem.Id;
                    InsertNewSyncItem(doc, x=> x.Routers, syncItem);
                    break;
                case InfrastructureEventType.EventsAggregatedEvent:
                    syncItem.Id = e.AggregatorId;
                    syncItem.Name = "Aggregator " + syncItem.Id;
                    InsertNewSyncItem(doc, x=> x.Aggregators, syncItem);
                    break;
                case InfrastructureEventType.TransactionExecutedEvent:
                    syncItem.Id = e.ChainId;
                    syncItem.Name = "Chain " + syncItem.Id;
                    InsertNewSyncItem(doc, x=> x.Chains, syncItem);
                    UpdateChainStatus(doc, e.ChainId, ChainStatus.Synced);
                    break;
                case InfrastructureEventType.RelayEventsTransmiitedEvent:
                    syncItem.Id = e.RelayId;
                    syncItem.Name = "Relay " + syncItem.Id;
                    InsertNewSyncItem(doc, x=> x.Relays, syncItem);
                    UpdateChainStatus(doc, e.ChainId, ChainStatus.InSync);
                    break;
                default:
                    return; 
            }

            InsertNewEvent(e.OperationId, infEv);

        }

        private InfrastructureEventItem CreateNewInfrastructureEvent(InfrastructureEvent e)
        {
            return new InfrastructureEventItem{
                PortalId = e.PortalId,
                OperationId = e.OperationId,
                AggreggatorId = e.AggregatorId,
                RouterId = e.RouterId,
                RelayId = e.RelayId,
                EventId = e.Id,
                ChainId = e.ChainId,
                CoreId = e.CoreId,
                DomainEvents = e.Events.Select(x=> x.ToJson()).ToList(),
                DomainCommands = e.Commands.Select(x=> x.ToJson()).ToList(),
                Type = e.EvntType,
                Timestamp = e.Timestamp.ToDateTime()
            };
        }

        private void InsertNewEvent(string operationId, InfrastructureEventItem e)
        {
            var builder = Builders<OperationDocument>.Update.AddToSet(x=> x.InfrastructureEvents,e);
            _operations.UpdateOne(x=> x.Id == operationId, builder);
        }

        private void InsertNewSyncItem(string operationId, Expression<Func<OperationDocument, IEnumerable<SyncItems>>> itemSelector, SyncItems item)
        {
            var builder = Builders<OperationDocument>.Update.AddToSet(itemSelector, item);
            _operations.UpdateOne(x=> x.Id == operationId, builder);
        }
        private void InsertNewSyncItem(OperationDocument doc, Expression<Func<OperationDocument, List<SyncItems>>> itemSelector, SyncItems item)
        {
            var items = itemSelector.Compile()(doc);
            if (!items.Any(x=> x.Id == item.Id && x.ErrorMessage == item.ErrorMessage))
            {
                items.Add(item);
                _operations.ReplaceOne(x=> x.Id == doc.Id, doc);
            }
        }

        private void UpdateChainStatus(OperationDocument doc, string chainId, ChainStatus status)
        {
            var perChainStatus = doc.PerChainStatus;
            foreach (var s in perChainStatus)
            {
                if (s.ChainId == chainId)
                {
                    s.Status = status;
                }
            }
            
            var builder = Builders<OperationDocument>.Update.Set(x => x.PerChainStatus, perChainStatus);
            _operations.UpdateOne(x => x.Id == doc.Id, builder);
        }
    }
}