using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BobMarley.Domain.Interfaces.Repositories
{
    public interface IMongoRepository<TEntity> : IDisposable where TEntity : class
    {
    }
}
