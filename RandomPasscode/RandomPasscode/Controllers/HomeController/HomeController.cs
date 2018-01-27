using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RandomPasscode.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RandomPasscode.Controllers.HomeController
{
    public class HomeController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            ViewBag.Password = new PasswordGen().GetPassword(14);
            ViewBag.Count = PasswordGen.GetCount();
            return View();
        }
        [HttpGet("/password")]
        public JsonResult Password()
        {
            return Json(new PasswordGen().GetPassword(14));
        }
    }
}
