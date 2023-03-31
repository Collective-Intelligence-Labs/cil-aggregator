namespace Cila.Documents
{
    public class OperationDocument
    {
        public string Id {get;set;}

        public string ClientID {get;set;}

        public DateTime Created {get;set;}
        public List<string> Commands {get;set;}
        public List<InfrastructureEventItem> InfrastructureEvents {get;set;}

        public OperationDocument()
        {
            InfrastructureEvents  = new List<InfrastructureEventItem>();
            Commands = new List<string>();
        }
    }

    public class InfrastructureEventItem {
        public DateTime Timestamp {get;set;}

        public InfrastructureEventType Type {get;set;}

        public string PortalId { get; set; }

        public string EventId {get;set;}

        public string RouterId {get;set;}

        public string RelayId {get;set;}

        public string CoreId {get;set;}

        public string AggreggatorId {get;set;}

        public string OperationId {get;set;}

        public List<string> DomainEvents {get;set;}

        public List<string> DomainCommands {get;set;}
    }

}