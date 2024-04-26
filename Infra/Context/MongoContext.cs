using BobMarley.Domain.Interfaces.Repositories;
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

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public MongoContext(string connection, string databaseName)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {
            _client = new MongoClient(connection);
            _database = _client.GetDatabase(databaseName);
        }

        public void Dispose()
        {
            ClientSession?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
