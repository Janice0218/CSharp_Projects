using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Dojodachi.Models;
using Microsoft.Data.OData.Atom;


// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Dojodachi.Controllers
{
    public class HomeController : Controller
    {
        
        // GET: /<controller>/




        public IActionResult Index()
    {
        
            ViewBag.Fullness = Dojoachi.Fullness;
            ViewBag.Happiness = Dojoachi.Happiness;
            ViewBag.Meals = Dojoachi.Meals;
            ViewBag.Energy = Dojoachi.Energy;
        ViewBag.Photo = Dojoachi.Photo;
            return View();
        }
        [HttpPost("GoAchi")]
        public IActionResult GoAchi(string activity)
        {
            
            switch (activity)
            {
                case "sleep":
                    Dojoachi.Sleep();
                    break;
                case "feed":
                    Dojoachi.Feed();
                    break;
                case "play":
                    Dojoachi.Play();
                    break;
                case "work":
                    Dojoachi.Work();
                    break;
            }
            return RedirectToAction("Index");
        }


      
    }
}
            