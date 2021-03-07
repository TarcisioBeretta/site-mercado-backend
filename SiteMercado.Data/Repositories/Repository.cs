using Microsoft.EntityFrameworkCore;
using SiteMercado.Core.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SiteMercado.Data.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext Context;

        public Repository(DbContext context)
        {
            Context = context;
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await Context.Set<TEntity>().ToListAsync();
        }

        public ValueTask<TEntity> GetById(int id)
        {
            return Context.Set<TEntity>().FindAsync(id);
        }

        public async Task Create(TEntity entity)
        {
            await Context.Set<TEntity>().AddAsync(entity);
        }

        public void Delete(TEntity entity)
        {
            Context.Set<TEntity>().Remove(entity);
        }
    }
}
