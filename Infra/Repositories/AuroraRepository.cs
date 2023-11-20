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
    }
}
