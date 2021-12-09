using DLL.Interfaces;
using DLL.Models;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Linq.Expressions;

namespace DLL.Repositoryes
{
    public abstract class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected MainContext dbContext;
        protected DbSet<TEntity> dbSet;

        public BaseRepository(MainContext context)
        {
            dbContext = context;
            dbSet = dbContext.Set<TEntity>();
        }

        public async Task CreateAsync(TEntity entity)
        {
            await dbSet.AddAsync(entity).ConfigureAwait(false);

            await dbContext.SaveChangesAsync();
        }

        public virtual async Task<IEnumerable<TEntity>> FindByCounditionAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await dbSet.Where(predicate)
                 .ToListAsync()
                 .ConfigureAwait(false);
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await dbSet.ToListAsync().ConfigureAwait(false);
        }

        public async Task UpdateEntityAsync(TEntity entity)
        {
            dbContext.Entry(entity).State = EntityState.Modified;
            await dbContext.SaveChangesAsync();
        }
    }
}
