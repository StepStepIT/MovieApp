using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Models
{
    internal class Actor
    {
        public int Id { get; set; }
        public Person ActorPersonData { get; set; }
        public List<Movie> Movies { get; set; }
        public string CharacterName { get; set; }
    }
}
