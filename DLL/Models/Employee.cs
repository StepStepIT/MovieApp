using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Models
{
    internal class Employee
    {
        public int Id { get; set; }
        public DateTime WorksFrom { get; set; }
        public Person EmployeePersonData { get; set; }
        public LoginData EmployeeLoginData { get; set; }
    }
}