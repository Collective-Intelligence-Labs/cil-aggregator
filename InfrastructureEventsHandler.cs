using Cila.Database;
using Cila.Documents;
using Google.Protobuf.WellKnownTypes;
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
            if (e.EvntType == InfrastructureEventType.ApplicationOperationInitiatedEvent)
            {
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
            }
            var infEv = CreateNewInfrastructureEvent(e);
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
    }
}