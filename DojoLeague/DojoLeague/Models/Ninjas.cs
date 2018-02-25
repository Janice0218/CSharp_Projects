using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DojoLeague.Models
{
    public class Ninjas
    {
        public string name { get; set; }
        public int level { get; set; }
        public Locations dojo { get; set; } = Locations.Rogue;
        public string description { get; set; }
    }

}
