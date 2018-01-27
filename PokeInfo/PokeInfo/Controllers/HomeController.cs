using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Newtonsoft.Json;
using PokeInfo.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PokeInfo.Controllers
{   
    public class HomeController : Controller
    {
        [HttpGet("{id}")]
        public async Task<IActionResult> Index(int id =1)
        {
            
            var pokeInfo = await PokemonApiReq.GetPokeInfo(id);
            ViewBag.Image = $"https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/{id}.png";
            return View(pokeInfo);

        }

 
    }
}

