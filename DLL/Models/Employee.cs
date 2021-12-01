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
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Salary { get; set; }
        public DateTime Birthday { get; set; }
        public DateTime WorksFrom { get; set; }
        public LoginData EmployeeLoginData { get; set; }
        public List<Booking> EmployeeBookings { get; set; }
    }
}