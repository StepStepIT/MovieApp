using DLL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Repositoryes
{
    public class MovieRepository : BaseRepository<Movie>
    {
        public MovieRepository(MainContext context) : base(context){ }

        public override async Task<IEnumerable<Movie>> GetAllAsync()
        {
            return await dbSet.Include(x => x.Sessions)
                .AsQueryable()
                .ToListAsync()
                .ConfigureAwait(false);
        }
        public override async Task<IEnumerable<Movie>> FindByCounditionAsync(Expression<Func<Movie, bool>> predicate)
        {
            return await dbSet.Where(predicate)
                .Include(x => x.Sessions)
                .ToListAsync()
                .ConfigureAwait(false);
        }
    }
}
