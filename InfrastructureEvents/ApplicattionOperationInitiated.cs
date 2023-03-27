namespace Cila
{
    public class ApplicationOperationInitiated : BaseInfrastructureEvent
    {
        public List<string> Commands { get; internal set; }
    }
}