using Cila.OmniChain;
using Google.Protobuf;
using Google.Protobuf.WellKnownTypes;
using OmniChain;

namespace Cila
{
    public class AggregatorService
    {
        public string Id { get; private set; }
        private List<IExecutionChain> _chains;

        private List<object> _eventStore;

        private List<int> _eventsHashes;

        private EventsDispatcher _dispatcher;

        private KafkaProducer _producer;

        public AggregatorService(OmniChainAggregatorSettings config, EventsDispatcher dispatcher, KafkaProducer producer)
        {
            _chains = new List<IExecutionChain>();
            _eventStore = new List<object>();
            _eventsHashes = new List<int>();
            _dispatcher = dispatcher;
            _producer = producer;
            Id = config.AggregatorId;
            foreach (var item in config.Chains)
            {
                var chain1 = new ExecutionChain();
                chain1.ChainService = new EthChainClient(item.Rpc,item.Contract,item.PrivateKey, item.Abi, config.SingletonAggregateID);
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
                    var infEvent = new InfrastructureEvent{
                        Id = Guid.NewGuid().ToString(),
                        EvntType = InfrastructureEventType.EventsAggregatedEvent,
                        AggregatorId = Id,
                        OperationId = Guid.NewGuid().ToString(),
                    };
                    infEvent.Events.Add( new DomainEventDto{
                            Id = e.EvntIdx.ToString(),
                            Timespan = Timestamp.FromDateTime(DateTime.UtcNow),
                    });
                    _producer.ProduceAsync("infr", infEvent);
                }
            }
            // find new events and dispatch them to events dispatcher
        }

    }
}