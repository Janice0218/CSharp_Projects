using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace PokeInfo.Models
{
    public class PokeDetails
    {

        public string Name;
        public IEnumerable<JObject> Types;
        public string Height;
        public string Weight;
        public string Id;
    }


}
