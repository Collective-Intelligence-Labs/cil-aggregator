using System.Linq.Expressions;
using Cila.Database;
using Cila.Documents;
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
                        Commands = e.Commands.Select(x=> x.ToString()).ToList(),
                        Created = DateTime.Now,
                        ClientID = e.PortalId
                 };
                 _operations.InsertOne(doc);
                };
            //}
            var infEv = CreateNewInfrastructureEvent(e);
            InsertNewEvent(e.OperationId, infEv);

            var syncItem = new SyncItems {

            };

            switch(infEv.Type)
            {
                case InfrastructureEventType.TransactionRoutedEvent:
                    InsertNewSyncItem(e.OperationId, x=> x.Routers, syncItem);
                    break;
                case InfrastructureEventType.EventsAggregatedEvent:
                    InsertNewSyncItem(e.OperationId, x=> x.Chains, syncItem);
                    InsertNewSyncItem(e.OperationId, x=> x.Aggregators, syncItem);
                    break;
                case InfrastructureEventType.RelayEventsTransmiitedEvent:
                    InsertNewSyncItem(e.OperationId, x=> x.Relays, syncItem);
                    break;
                default:
                    return; 
            }
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
                DomainEvents = e.Events.Select(x=> x.Id).ToList(),
                DomainCommands = e.Commands.Select(x=> x.Id).ToList(),
                //Timestamp = e.Timestamp??ToDateTime()
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
    }
}