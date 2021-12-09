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
    public class ChairRepository : BaseRepository<Chair>
    {
        public ChairRepository(MainContext context) : base(context){ }

        public override async Task<IEnumerable<Chair>> GetAllAsync()
        {
            return await dbSet.Include(x => x.Booking)
                .Include(x => x.Hall)
                .ToListAsync()
                .ConfigureAwait(false);
        }
        public override async Task<IEnumerable<Chair>> FindByCounditionAsync(Expression<Func<Chair, bool>> predicate)
        {
            return await dbSet.Where(predicate)
                .Include(x => x.Booking)
                .Include(x => x.Hall)
                .ToListAsync()
                .ConfigureAwait(false);
        }
    }
}
