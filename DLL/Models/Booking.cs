using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//
namespace DLL.Models
{
    internal class Booking
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public int SessionId { get; set; }
        public Session Session { get; set; }
        public DateTime Date { get; set; }
        public string CustomerName { get; set; }
        public string CustomerPhone { get; set; }
        public List<Chair> Chairs { get; set; }
        public double TotalPrice { get; set; }
        public bool isPaid { get; set; }
        public bool isCanceled { get; set; }
    }
}
