namespace Cila
{
    public class BaseInfrastructureEvent
    {
        public string Id {get;set;}

        public string SourceId {get;set;}

        public string OperationId {get;set;}

        public DateTime Happened { get; internal set; }
    }
}