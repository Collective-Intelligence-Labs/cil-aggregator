using Cila.Documents;
using MongoDB.Driver;

namespace Cila.Database {

    public class MongoDatabase: IDatabase
    {
        private MongoClient _client;

        public MongoDatabase(OmniChainAggregatorSettings settings)
        {
            _client = new MongoClient(settings.MongoDBConnectionString);
        }

        public IMongoCollection<DomainEvent> GetEvents()
        {
            return _client.GetDatabase("relay").GetCollection<DomainEvent>("events");
        }

        public IMongoCollection<OperationDocument> GetOperations()
        {
            return _client.GetDatabase("aggregator").GetCollection<OperationDocument>("opeations");
        }
    }
}
