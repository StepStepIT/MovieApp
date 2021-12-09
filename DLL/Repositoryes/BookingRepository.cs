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
    public class BookingRepository : BaseRepository<Booking>
    {
        public BookingRepository(MainContext context) : base(context) { }

        public override async Task<IEnumerable<Booking>> GetAllAsync()
        {
            return await dbSet.Include(x => x.Employee)
                .Include(x => x.Session)
                .Include(x => x.Chair)
                .ToListAsync()
                .ConfigureAwait(false);
        }
        public override async Task<IEnumerable<Booking>> FindByCounditionAsync(Expression<Func<Booking, bool>> predicate)
        {
            return await dbSet.Where(predicate)
                .Include(x => x.Employee)
                .Include(x => x.Session)
                .Include(x => x.Chair)            
                .ToListAsync()
                .ConfigureAwait(false);
        }
 
    }
}
