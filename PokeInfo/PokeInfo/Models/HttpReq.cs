using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PokeInfo.Models
{
    public class HttpReq
    {
        public static object BasicRequest()
        {
            var client = new HttpClient();
            var response = client.GetAsync("https://pokeapi.co/api/v2/pokemon-form/1/").Result;
            var convertToString = response.Content.ReadAsStringAsync().Result;
            var JsonObj = JsonConvert.DeserializeObject(convertToString);
            return JsonObj;
        }

        public static async Task<Dictionary<string,object>> AsyncroRequest()
        {
            var client = new HttpClient();
            var response = await client.GetAsync("https://pokeapi.co/api/v2/pokemon-form/1/");
            var serialToStr = await response.Content.ReadAsStringAsync();
            //this time we save to a dictionary so that we can query what we want to return using Newtonsoft.Json.Linq.jObject
            Dictionary<string,object> jObj= JsonConvert.DeserializeObject<Dictionary<string,object>>(serialToStr);
            return jObj;

        }   
        
    }

    
}

