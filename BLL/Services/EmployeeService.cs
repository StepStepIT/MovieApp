using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DLL.Models;
using DLL.Repositoryes;

namespace BLL.Services
{
    public class EmployeeService 
    {
        private readonly EmployeeRepository employeeRepository;

        public EmployeeService(EmployeeRepository repository)
        {
            employeeRepository = repository;
        }
    }
}
