using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheWall.Models
{
    public class WallViewModel
    {
        public User user { get; set; }
        public Message message { get; set; }
        public Comment comment { get; set; }

    }
}
