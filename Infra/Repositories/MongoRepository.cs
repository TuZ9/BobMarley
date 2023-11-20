using BobMarley.Domain.Interfaces.Repositories;
using BobMarley.Infra.Context;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;

namespace BobMarley.Infra.Repositories
{
    public abstract class MongoRepository<TEntity, YEntity> : IMongoRepository<TEntity> where TEntity : class where YEntity : class, IDisposable
    {
        protected readonly MongoContext _context;
        protected IMongoCollection<TEntity> _dbSet;
        protected readonly ILogger<YEntity> _logger;

        protected MongoRepository(MongoContext _context, ILogger<YEntity> logger)
        {
            _context = _context;
            _logger = logger;
            _dbSet = _context.Database.GetCollection<TEntity>(typeof(TEntity).Name);
        }

        public Task Update(List<TEntity> objs)
        {
            try
            {
                var builder = Builders<TEntity>.Filter;
                var filter = builder.Empty;
                foreach (var obj in objs)
                {
                    var field = obj.GetType().GetProperties().FirstOrDefault(x => x.GetCustomAttributes(false).Any()).Name;
                    var IdProperty = obj.GetType().GetProperties().FirstOrDefault(x => x.GetCustomAttributes(false).Any()).GetValue(obj);
                    filter = builder.Eq(field, IdProperty);
                    filter |= filter;
                }
                var dynamicQuery = builder.Or(filter);
                _dbSet.DeleteManyAsync(dynamicQuery);
                _dbSet.InsertManyAsync(objs);
                return Task.CompletedTask;
            }
            catch (Exception ex) 
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task DropCollection(string collectionName)
        {
            _dbSet.Database.DropCollection(collectionName);
        }

        public async Task<TEntity> GetAsync(string field, string value)
        {
            try
            {
                var data = await _dbSet.FindAsync(Builders<TEntity>.Filter.Eq(field, value));
                Dispose();
                return data.SingleOrDefault();
            }
            catch (Exception ex)
            {
                _logger.LogError("Erro na busca");
                throw new Exception(ex.Message);
            }
        }

        public async Task InsertBulk(IEnumerable<WriteModel<TEntity>> obj)
        {
            try
            {
                await _dbSet.BulkWriteAsync(obj, new BulkWriteOptions());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
