using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//
namespace DLL.Models
{
    internal class Session
    {
        public int Id { get; set; }
        public Movie Movie { get; set; }
        public Auditorium Auditorium { get; set; }
        public DateTime DateStart { get; set; }
        public List<Booking> SessionBookings { get; set; }
    }
}
