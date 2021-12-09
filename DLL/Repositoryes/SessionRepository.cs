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
    public class SessionRepository : BaseRepository<Session>
    {
        public SessionRepository(MainContext context) : base(context) { }

        public override async Task<IEnumerable<Session>> GetAllAsync()
        {
            return await dbSet.Include(x => x.Bookings)
                .Include(x => x.Hall)
                .Include(x => x.Movie)
                .ToListAsync().ConfigureAwait(false);
        }

        public override async Task<IEnumerable<Session>> FindByCounditionAsync(Expression<Func<Session, bool>> predicate)
        {
            return await dbSet.Where(predicate)
                .Include(x => x.Hall)
                .Include(x => x.Movie)
                .ToListAsync().ConfigureAwait(false);
        }
    }
}
