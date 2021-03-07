using System.Collections.Generic;
using System.Threading.Tasks;

namespace SiteMercado.Core.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAll();
        ValueTask<TEntity> GetById(int id);
        Task Create(TEntity entity);
        void Delete(TEntity entity);
    }
}