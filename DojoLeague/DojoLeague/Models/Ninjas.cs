﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DojoLeague.Models
{
    public class Ninjas
    {
        public int id { get; set; }
        public string name { get; set; }
        public int level { get; set; }
        public string dojo { get; set; } = Rogue;
        public string description { get; set; }
    }

}