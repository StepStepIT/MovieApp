using DLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Interfaces
{
    public interface IRepository<TEntity> 
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<IEnumerable<TEntity>> FindByCounditionAsync(Expression<Func<TEntity, bool>> predicate);
        Task CreateAsync(TEntity entity);
        Task UpdateEntityAsync(TEntity entity);
    }
}
