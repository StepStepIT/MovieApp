using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Models
{
    internal class Auditorium
    {
        public int Id { get; set; }
        public int AuditoriumNumber { get; set; }
        public List<Chair> Chairs { get; set; }
    }
}
