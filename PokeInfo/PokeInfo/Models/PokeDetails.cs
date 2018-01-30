using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace PokeInfo.Models
{
    public class PokeDetails
    {
        
        public string Name;
        public List<string> Types = new List<string>();
        public string Height;
        public string Weight;
        public string Id;

        public PokeDetails(JObject data)
        {
            Name = (string)data["name"];
        }


    }
}
