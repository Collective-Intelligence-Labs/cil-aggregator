using Cila.OmniChain;

namespace Cila
{
    public interface IExecutionChain
    {
        string ID {get;}

        //List<IAggregateState> Aggregates {get;set;}
    
        IEnumerable<DomainEvent> Update();
    
        int Length {get;}
    }

    public class ExecutionChain : IExecutionChain
    {
        public string ID { get; set; }
        public int Length { get => _events.Count; }
        internal IChainClient ChainService { get => chainService; set => chainService = value; }

        private SortedList<int,DomainEvent> _events = new SortedList<int, DomainEvent>();
        private IChainClient chainService;

        public ExecutionChain()
        {
        }

        public IEnumerable<DomainEvent> Update()
        {
            var newEvents = ChainService.Pull(Length);
            foreach (var e in newEvents)
            {
                
                _events.Add((int)e.EventNumber, e);
                yield return e;
            }
            
        }
    }
}