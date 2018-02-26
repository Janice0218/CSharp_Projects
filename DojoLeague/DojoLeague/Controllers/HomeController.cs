using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DojoLeague.Models;
using Microsoft.AspNetCore.Mvc;



namespace DojoLeague.Controllers
{
    public class HomeController : Controller
    {
        private DataFactory _data;

        public HomeController(DataFactory data)
        {
            _data = data;
        }

        public IActionResult Ninjas() => View(new NinjasViewModel(){ninjas = _data.GetNinjas()});

        public IActionResult Dojos()
        {
            return View(new DojosViewModel {dojos = _data.GetDojos() });
        }

        [HttpPost]
        public IActionResult CreateNinja(Ninjas ninja)
        {
            _data.AddNinja(ninja);
            return RedirectToAction("Ninjas");
        }

        [HttpPost]
        public IActionResult CreateDojo(Dojos dojo)
        {
            _data.AddDojo(dojo);
            return RedirectToAction("Dojos");
        }

//        public IActionResult ShowDojo(int id)
//        {
//            var result =_data.GetDojoById(id);
//            return View(result);
//        }
        public IActionResult ShowNinja(int id)
        {
            var result =_data.GetNinjaById(id);
            return View(result);
        }
        public IActionResult ShowDojo(string location)
        {
            var result =_data.GetDojoByLocation(location);
            return View(result);
        }
    }
}
