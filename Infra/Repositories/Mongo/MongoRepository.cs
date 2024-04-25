using BobMarley.Domain.Interfaces.Repositories;
using BobMarley.Infra.Context;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;

namespace BobMarley.Infra.Repositories.Mongo
{
    public abstract class MongoRepository<TEntity, YEntity> : IMongoRepository<TEntity> where TEntity : class where YEntity : class, IDisposable
    {
        protected readonly MongoContext _context;
        protected IMongoCollection<TEntity> _dbSet;
        protected readonly ILogger<YEntity> _logger;

        protected MongoRepository(MongoContext context, ILogger<YEntity> logger)
        {
            _context = context;
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

        public void DropCollection(string collectionName)
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

        public async Task CreateIndexAsync(string fieldName)
        {
            try
            {
                var options = new CreateIndexOptions { Unique = true };

                await _dbSet.Indexes.CreateOneAsync($"{{ {fieldName} : 1 }}");
            }
            catch (Exception ex)
            {
                _logger.LogError("Erro Create Index Collection Mongo");
                Dispose();
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            try
            {
                var all = await _dbSet.Find(Builders<TEntity>.Filter.Empty)
                    .ToListAsync();

                Dispose();
                return all.ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError("Erro GetAll");
                Dispose();
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<TEntity>> GetAllPagted(int page, int pageSize)
        {
            try
            {
                var all = await _dbSet.Find(Builders<TEntity>.Filter.Empty)
                    .Skip((page - 1) * pageSize)
                    .Limit(pageSize)
                    .ToListAsync();

                Dispose();
                return all.ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError("Erro GetAll");
                Dispose();
                throw new Exception(ex.Message);
            }
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
