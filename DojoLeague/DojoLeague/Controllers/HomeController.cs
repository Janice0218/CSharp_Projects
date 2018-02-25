using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DojoLeague.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DojoLeague.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Ninjas()
        {
            return View(new NinjasViewModel {ninjas = new List<Ninjas>() });
        }
        public IActionResult Dojos()
        {
            return View(new DojosViewModel {dojos = new List<Dojos>() });
        }

        [HttpPost]
        public IActionResult CreateNinja(Ninjas ninja)
        {
            return RedirectToAction("Ninjas");
        }

        [HttpPost]
        public IActionResult CreateDojo(Dojos dojo)
        {
            return RedirectToAction("Dojos");
        }
    }
}
