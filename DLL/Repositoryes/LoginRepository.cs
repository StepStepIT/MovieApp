using DLL.Context;
using DLL.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DLL.Repositoryes
{
    public class LoginRepository : BaseRepository<LoginData>
    {
        public LoginRepository(MainContext context) : base(context) { }

        public override async Task<IEnumerable<LoginData>> FindByCounditionAsync(Expression<Func<LoginData, bool>> predicate)
        {
            return await dbSet.Where(predicate)
                .Include(x => x.Employee)               
                .ToListAsync()
                .ConfigureAwait(false);
        }
  
    }
}
