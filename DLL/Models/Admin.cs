using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Models
{
    internal class Admin
    {
        public int Id { get; set; }
        public Person AdminPersonData { get; set; }
        LoginData AdminLoginData { get; set; }
    }
}
