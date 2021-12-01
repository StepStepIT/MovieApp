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
        public Employee Employee { get; set; }
        public Session Session { get; set; }
        public DateTime BookingDate { get; set; }
        public string CustomerName { get; set; }
        // phone num місце
        public bool isPaid { get; set; }
        public bool isCanceled { get; set; }
    }
}
