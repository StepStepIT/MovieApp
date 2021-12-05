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
        public int Number { get; set; }
        public int ChairId { get; set; }
        public List<Chair> Chairs { get; set; }
        public int SessionId { get; set; }
        public List<Session> Sessions { get; set; }
    }
}
