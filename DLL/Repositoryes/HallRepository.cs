using DLL.Context;
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
    public class HallRepository : BaseRepository<Hall>
    {
        public HallRepository(MainContext context) : base(context) { }

        public override async Task<IEnumerable<Hall>> GetAllAsync()
        {
            return await dbSet.Include(x =>x.Sessions)
                .Include(x => x.Chairs)
                .ToListAsync()
                .ConfigureAwait(false);
        }
        public override async Task<IEnumerable<Hall>> FindByCounditionAsync(Expression<Func<Hall, bool>> predicate)
        {
            return await dbSet.Where(predicate)
                .Include(x => x.Sessions)
                .Include(x => x.Chairs)
                .ToListAsync()
                .ConfigureAwait(false);
        }
    }
}
