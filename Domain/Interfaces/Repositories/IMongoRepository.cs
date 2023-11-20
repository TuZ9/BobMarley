using MongoDB.Driver;

namespace BobMarley.Domain.Interfaces.Repositories
{
    public interface IMongoRepository<TEntity> : IDisposable where TEntity : class
    {
        Task DropCollection(string collectionName);
        Task Update(List<TEntity> objs);
        Task<TEntity> GetAsync(string field, string value);
        Task InsertBulk(IEnumerable<WriteModel<TEntity>> obj);
        Task<IEnumerable<TEntity>> GetAllPagted(int page, int pageSize);
        Task<IEnumerable<TEntity>> GetAll();
        Task CreateIndexAsync(string fieldName);
    }
}