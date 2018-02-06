using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PokeInfo.Models;
using Newtonsoft.Json.Linq;

namespace PokeInfo.Models
{
    public static class PokemonApiReq
    {
        public static async Task<Object> GetPokeInfo(int id)
        {
            using (var client = new HttpClient())
            {
                    client.BaseAddress = new Uri("http://pokeapi.co/api/v2/");
                    var request = await client.GetAsync($"pokemon/{id}");
                    var result = await request.Content.ReadAsStringAsync();
                    
                    // your PokeDetails class isn't going to map perfectly to the 'result' string here with just DeserializeObject<PokeDetails>
                    // like, what is it going to do with types!
                    // i would suggest adding a constructor to PokeDetails and doing it manually, by serializing the result
                    // as a JObject () and passing to PokeDetails constructor
                var final = JsonConvert.DeserializeObject<PokeDetails>(result);
                    return final;
                
                

            }


        }
    }
}
