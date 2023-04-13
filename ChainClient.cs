
using Nethereum.Web3;
using Nethereum.Contracts;
using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.RPC.Eth.DTOs;
using System.Numerics;
using Nethereum.Contracts.ContractHandlers;
using Nethereum.JsonRpc.Client;
using Nethereum.Hex.HexTypes;
using OmniChain;

namespace Cila.OmniChain
{
    public class LoggingInterceptor : RequestInterceptor
    {
        public override Task InterceptSendRequestAsync(Func<string, string, object[], Task> interceptedSendRequestAsync, string method, string route = null, params object[] paramList)
        {
            Console.WriteLine($"Method: {method}");
            Console.WriteLine($"Params: {string.Join(", ", paramList)}");
            return interceptedSendRequestAsync(method,route,paramList);
        }
    }

    public interface IChainClient
    {
        List<byte[]> Pull(ulong position, string aggregateId);
        Task<List<byte[]>> PullAsync(ulong position, string aggregateId);
    }

    [Function("pull")]
    public class PullFuncation: FunctionMessage
    {
        [Parameter("address", "aggregateId", 1)]
        public string AggregateId {get;set;}

        [Parameter("uint", "startIndex", 2)]
        public int StartIndex {get;set;}

        [Parameter("uint", "limit", 3)]
        public int Limit {get;set;}
    }

    [Function("pullBytes")]
    public class PullBytesFuncation: FunctionMessage
    {
        [Parameter("string", "aggregateId", 1)]
        public string AggregateId {get;set;}

        [Parameter("uint", "startIndex", 2)]
        public int StartIndex {get;set;}

        [Parameter("uint", "limit", 3)]
        public int Limit {get;set;}
    }

    [Function("push")]
    public class PushFuncation: FunctionMessage
    {
        [Parameter("address", "_aggregateId", 1)]
        public string AggregateId { get; set; }

        [Parameter("uint", "_position", 2)]
        public int Position {get;set;}

        [Parameter("DomainEvent[]", "events", 3)]
        public List<DomainEvent> Events {get;set;}
    }

    public class EthChainClient : IChainClient
    {
        private Web3 _web3;
        private ContractHandler _handler;
        private Event<OmnichainEvent> _eventHandler;
        private NewFilterInput _filterInput;
        private string _privateKey;

        public EthChainClient(string rpc, string contract, string privateKey)
        {
            
            _privateKey = privateKey;
            var account = new Nethereum.Web3.Accounts.Account(privateKey);
            _web3 = new Web3(account, rpc);
            _web3.Client.OverridingRequestInterceptor = new LoggingInterceptor();
            _handler = _web3.Eth.GetContractHandler(contract);
            _eventHandler = _handler.GetEvent<OmnichainEvent>();
            var block = _web3.Eth.Blocks.GetBlockNumber.SendRequestAsync().Result;
            _filterInput = _eventHandler.CreateFilterInput(new BlockParameter(block.ToUlong() - 1024), BlockParameter.CreateLatest());
            //
        }

        public const int MAX_LIMIT = 1000000;

        public async Task<List<byte[]>> PullAsync(ulong position, string aggregateId)
        {
             Console.WriteLine("Chain Service Pull execution started from position: {0}, aggregate: {1}", position, aggregateId);
             var handler = _handler.GetFunction<PullBytesFuncation>();
             var request = new PullBytesFuncation{
                StartIndex = (int)position,
                    Limit = MAX_LIMIT,
                    AggregateId = aggregateId
                };
                var result =  await handler.CallAsync<PullEventsDTO>(request);
                Console.WriteLine("Chain Service Pull executed: {0}", result);
                //return result.Events;   
                return result.Events;
        }

        public DomainEvent Deserizlize(byte[] data)
        {
            return new DomainEvent();
        }

        public List<byte[]> Pull(ulong position, string aggregateId)
        {
            return PullAsync(position, aggregateId).GetAwaiter().GetResult();
        }
    }

    [FunctionOutput]
    public class PullEventsDTO: IFunctionOutputDTO
    {
        [Parameter("bytes[]",order:1)]
        public List<byte[]> Events {get;set;}
    }

    [Event("OmnichainEvent")]
    public class OmnichainEvent: IEventDTO
    {
        [Parameter("uint64", "_idx", 1, true)]
        public ulong Version { get; set; }

        [Parameter("uint8", "_type", 2, true)]
        public byte Type { get; set; }

        [Parameter("bytes", "_payload", 3, true)]
        public byte[] Payload { get; set; }
    }
}