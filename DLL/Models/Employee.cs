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
        public string Role { get; set; }
        public int Salary { get; set; }
        public DateTime Birthday { get; set; }
        public DateTime WorksFrom { get; set; }
        public int LoginDataId { get; set; }
        public LoginData LoginData { get; set; }
        public List<Booking> Bookings { get; set; }
    }
}