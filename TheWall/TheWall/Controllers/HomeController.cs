using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DbConnection;
using Microsoft.AspNetCore.Mvc;


// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TheWall.Controllers
{
    public class HomeController : Controller
    {
        private DbConnector _dbConnector;

        public HomeController(DbConnector dbConnector)
        {
            _dbConnector = dbConnector;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public RedirectToActionResult Login()
        {
            return RedirectToAction("Test");
        }

        public IActionResult Register()
        {
            return View();
        }


        public IActionResult Test()
        {
            var result =_dbConnector.Query(@"select * from users");
            return View(result);
        }
    }
}
