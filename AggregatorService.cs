using Cila.OmniChain;

namespace Cila
{
    public class AggregatorService
    {
        public string Id { get; private set; }
        private List<IExecutionChain> _chains;

        private List<object> _eventStore;

        private List<int> _eventsHashes;

        private EventsDispatcher _dispatcher;

        public AggregatorService(OmniChainAggregatorSettings config)
        {
            _chains = new List<IExecutionChain>();
            _eventStore = new List<object>();
            _eventsHashes = new List<int>();
            _dispatcher = new EventsDispatcher();
            Id = config.AggregatorId;
            foreach (var item in config.Chains)
            {
                var chain1 = new ExecutionChain();
                chain1.ChainService = new EthChainClient(item.Rpc,item.Contract,item.PrivateKey, item.Abi, item.SingletonAggregateID);
                Console.WriteLine("Creating chain with RPC: {0}, Private Key: {2}, Contract: {1}", item.Rpc,item.Contract,item.PrivateKey);
                _chains.Add(chain1);
            }
        }

        public void PullNewEvents()
        {
            //fetch the latest state for each chains
            Console.WriteLine("Current active chains: {0}", _chains.Count);
            foreach (var chain in _chains)
            {
                var current = chain.Length;
                var newEvents = chain.Update();
                foreach (var e in newEvents)
                {
                    if (!_eventsHashes.Contains(e.GetHashCode()))
                    {
                        _eventStore.Add(e);
                        _dispatcher.DispatchEvent(e);
                    }
                }
            }
            // find new events and dispatch them to events dispatcher
        }

    }
}