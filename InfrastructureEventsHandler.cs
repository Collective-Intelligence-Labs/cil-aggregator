using Cila.Documents;
using MongoDB.Driver;

namespace Cila 
{
    public class InfrastructureEventsHandler: IEventHandler
    {
        private readonly IMongoCollection<OperationDocument> _operations;

        public InfrastructureEventsHandler(IMongoCollection<OperationDocument> operations)
        {
            _operations = operations;
        }

        public void Handle(ApplicationOperationInitiated e)
        {
            var doc = new OperationDocument{
                    Id = e.OperationId,
                    Commands = e.Commands,
                    Created = DateTime.Now,
                    ClientID = e.SourceId,
            };
            var infEv = CreateNewInfrastructureEvent(e);
            infEv.Type = InfrastructureEventType.ApplicattionOperationInitiated;
            doc.InfrastructureEvents.Add(infEv);
            _operations.InsertOne(doc);
        }

        public void Handle(EventsPushedNoConflict e)
        {
            var inEv = CreateNewInfrastructureEvent(e);
            inEv.Type = InfrastructureEventType.EventsPushedNoConflict;
            InsertNewEvent(e.OperationId,inEv);
        }

        public void Handle(EventsPushedWithConflict e)
        {
            var inEv = CreateNewInfrastructureEvent(e);
            inEv.Type = InfrastructureEventType.EventsPushedWithConflict;
            InsertNewEvent(e.OperationId,inEv);
        }
        public void Handle(RelayEventsTransmiited e)
        {
            var inEv = CreateNewInfrastructureEvent(e);
            inEv.Type = InfrastructureEventType.EventsTrasmitted;
            InsertNewEvent(e.OperationId,inEv);
        }
        public void Handle(TransactionExecuted e)
        {
            var inEv = CreateNewInfrastructureEvent(e);
            inEv.Type = InfrastructureEventType.TransactionExecuted;
            InsertNewEvent(e.OperationId,inEv);
        }
        public void Handle(TransactionRouted e)
        {
            var inEv = CreateNewInfrastructureEvent(e);
            inEv.Type = InfrastructureEventType.TransactionRouted;
            InsertNewEvent(e.OperationId,inEv);
        }

        private InfrastructureEvent CreateNewInfrastructureEvent(BaseInfrastructureEvent e)
        {
            return new InfrastructureEvent{
                Originator = e.SourceId,
                Happened = e.Happened,
                ID = e.Id,
                Message = e.ToString(),
            };
        }

        private void InsertNewEvent(string operationId, InfrastructureEvent e)
        {
            var builder = Builders<OperationDocument>.Update.AddToSet(x=> x.InfrastructureEvents,e);
            _operations.UpdateOne(x=> x.Id == operationId, builder);
        }
    }
}