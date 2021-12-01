using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//
namespace DLL.Models
{
    internal class Chair
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public int Row { get; set; }
        public bool IsBusy { get; set; }
        public double Cost { get; set; }
        public string ClientName { get; set; }
    }
}
