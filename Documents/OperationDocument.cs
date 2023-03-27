namespace Cila.Documents
{
    public class OperationDocument
    {
        public string Id {get;set;}

        public string ClientID {get;set;}

        public DateTime Created {get;set;}
        public List<string> Commands {get;set;}
        public List<InfrastructureEvent> InfrastructureEvents {get;set;}

        public OperationDocument()
        {
            InfrastructureEvents  = new List<InfrastructureEvent>();
            Commands = new List<string>();
        }
    }

    public class InfrastructureEvent {
        public DateTime Happened {get;set;}

        public InfrastructureEventType Type {get;set;}

        public string Originator { get; set; }

        public string ID {get;set;}

        public string Message {get;set;}
    }

    public enum InfrastructureEventType
    {
        ApplicattionOperationInitiated,
        TransactionRouted,
        TransactionExecuted,
        EventsTrasmitted,
        EventsPushedNoConflict,
        EventsPushedWithConflict,
        EventsAggregated
    }
}