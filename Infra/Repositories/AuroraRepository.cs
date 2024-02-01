using BobMarley.Domain.Interfaces.Repositories;
using BobMarley.Infra.Context;

namespace BobMarley.Infra.Repositories
{
    public abstract class AuroraRepository<TEntity> : IAuroraRepository<TEntity> where TEntity : class
    {
        protected readonly AuroraDbContext _context;

        public AuroraRepository(AuroraDbContext context)
        {
            _context = context;
        }
        public Task Delete(Guid Id)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> GetById(Guid Id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TEntity>> GetListAsync()
        {
            throw new NotImplementedException();
        }

        public Task Insert(IEnumerable<TEntity> list)
        {
            throw new NotImplementedException();
        }

        public Task Update(IEnumerable<TEntity> list)
        {
            throw new NotImplementedException();
        }
    }
}