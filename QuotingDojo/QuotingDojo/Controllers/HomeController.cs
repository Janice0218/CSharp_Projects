using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DbConnection;
using Microsoft.AspNetCore.Mvc;
using QuotingDojo.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace QuotingDojo.Controllers
{
    public class HomeController : Controller
    {
       [HttpGet("")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("/quotes")]
        public IActionResult Show()
        {
            var query = DbConnector.Query(@"Select * from users");
            return View(query);
        }

        [HttpPost("/quotes")]
        public IActionResult Create(User user)
        {
            var query =
                $@"insert into users(name,quote,created_at, updated_at)values('{user.name}', '{user.quote}', NOW(), NOW())";
            DbConnector.Execute(query);
            return RedirectToAction("Show");
        }
    }
}
