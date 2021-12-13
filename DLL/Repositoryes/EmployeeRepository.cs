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
    public class EmployeeRepository : BaseRepository<Employee>
    {
        public EmployeeRepository(MainContext context) : base(context){ }

        public override async Task<IEnumerable<Employee>> GetAllAsync() 
        {
            return await dbSet.Include(x => x.Bookings)
                .Include(s => s.LoginData)
                .ToListAsync()
                .ConfigureAwait(false);
        }
        public async Task<IEnumerable<Employee>> GetAllEmployeeWithoutLoginData()
        {
            return await dbSet.Include(x => x.Bookings)
              .ToListAsync()
              .ConfigureAwait(false);
        }
        public override async Task<IEnumerable<Employee>> FindByCounditionAsync(Expression<Func<Employee, bool>> predicate)
        {
           return await dbSet.Where(predicate)
                .Include(x => x.Bookings)              
                .ToListAsync()
                .ConfigureAwait(false);
        }
    }
}
