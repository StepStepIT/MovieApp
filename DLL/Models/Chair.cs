using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//
namespace DLL.Models
{
    public class Chair
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public int Row { get; set; }
        public bool IsBusy { get; set; }
        public double Cost { get; set; }
        public int HallId { get; set; }
        public Hall Hall { get; set; }
        public int BookingId { get; set; }
        public Booking Booking { get; set; }
    }
}
