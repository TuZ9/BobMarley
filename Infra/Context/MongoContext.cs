using BobMarley.Domain.Interfaces.Repositories.Mongo;
using MongoDB.Driver;

namespace BobMarley.Infra.Context
{
    public class MongoContext : IMongoContext
    {

        private MongoClient _client;
        private IMongoDatabase _database;
        public IClientSessionHandle ClientSession { get; set; }
        public MongoClient Client { get { return this._client; } }
        public IMongoDatabase Database { get { return this._database; } }

        public MongoContext(string connection, string databaseName)
        {
            _client = new MongoClient(connection);
            _database = _client.GetDatabase(databaseName);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
