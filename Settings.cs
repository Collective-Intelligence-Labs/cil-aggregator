namespace Cila
{
    public class OmniChainAggregatorSettings
    {
        public string RelayId {get;set;}

        public List<ExecutionChainSettings> Chains {get;set;}

        public OmniChainAggregatorSettings()
        {
            Chains = new List<ExecutionChainSettings>();
        }
    }

    public class ExecutionChainSettings
    {
        public string Rpc { get; set; } 

        public string PrivateKey { get; set; }  

        public string Contract { get; set; }

        public string AbiFile {get;set;}

        private string _abi;
        public string Abi {get {
                _abi = _abi ?? File.ReadAllText(AbiFile);
            return _abi;
        }}
    }
}