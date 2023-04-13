using Cila.Documents;
using MongoDB.Driver;

namespace Cila.Database {

    public class MongoDatabase: IDatabase
    {
        private MongoClient _client;

        private const string _dbname = "aggregator";

        private class Collections {
            public static string Events  = "events";
            public static string Subscriptions  = "subscriptions";
            public static string Chains  = "chains";
            public static string Executions  = "executions";
            public static string AggregatedEvents = "aggregated-events";
        }

        public MongoDatabase(OmniChainSettings settings)
        {
            _client = new MongoClient(settings.MongoDBConnectionString);
        }

        public IMongoCollection<DomainEvent> GetEvents()
        {
            return _client.GetDatabase("relay").GetCollection<DomainEvent>("events");
        }

        public IMongoCollection<AggregatedEventDocument> GetAggregatedEventsCollection()
        {
            return _client.GetDatabase(_dbname).GetCollection<AggregatedEventDocument>(Collections.AggregatedEvents);
        }

        public IMongoCollection<OperationDocument> GetOperations()
        {
            return _client.GetDatabase(_dbname).GetCollection<OperationDocument>("operations");
        }

        public IMongoCollection<NFTDocument> GetNfts()
        {
            return _client.GetDatabase(_dbname).GetCollection<NFTDocument>("nfts");
        }


        public IMongoCollection<ChainDocument> GetChainsCollection()
        {
            return _client.GetDatabase(_dbname).GetCollection<ChainDocument>(Collections.Chains);
        }

        public IEnumerable <OperationDocument> FindAllOperations()
        {
            var filter = Builders<OperationDocument>.Filter.Empty;
            return GetOperations().Find(filter).ToList();
        }

        public OperationDocument FindOne(string operationId)
        {
            var filter = Builders<OperationDocument>.Filter.Eq(x=> x.Id, operationId);
            return GetOperations().Find(filter).FirstOrDefault();
        }

    }
}
