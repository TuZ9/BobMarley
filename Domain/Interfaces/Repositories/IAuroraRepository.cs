
namespace BobMarley.Domain.Interfaces.Repositories
{
    public interface IAuroraRepository<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetListAsync();
        Task<TEntity> GetById(Guid Id);
        Task Update(IEnumerable<TEntity> list);
        Task Insert(IEnumerable<TEntity> list);
        Task Delete(Guid Id);
    }
}
