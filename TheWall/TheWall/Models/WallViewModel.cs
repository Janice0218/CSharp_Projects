using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheWall.Models
{
    public class WallViewModel
    {
        public List<Dictionary<string,object>> Messages { get; set; }
        public List<Dictionary<string,object>> Comments { get; set; }

    }
}
