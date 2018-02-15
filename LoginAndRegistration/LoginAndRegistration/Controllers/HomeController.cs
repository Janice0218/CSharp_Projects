using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LoginAndRegistration.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LoginAndRegistration.Controllers
{
    public class HomeController : Controller
    {
        private DBConnector _dbConnector;

        public HomeController(DBConnector dbConnector)
        {
            _dbConnector = dbConnector;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(User user)
        {
            if (ModelState.IsValid)
            {
                var query =
                    $"Insert into users(first_name, last_name, email, password, created_at, updated_at) values('{user.first_name}','{user.last_name}', '{user.email}','{user.password}', now(), now())";
                _dbConnector.Execute(query);
                var addedUser = _dbConnector.Query($"Select * from users where id=LAST_INSERT_ID()");
                TempData["user"] = addedUser[0]["first_name"];
                return View("Success");
            }

            return View();
        }

        public IActionResult Success() => View();

        public IActionResult Login() => View();

        [HttpPost]
        public IActionResult LogIn(Login user)
        {
            var query = $"Select * from users where email = '{user.email}'";
            var result = _dbConnector.Query(query);
            if (result.Count == 0)
            {
                ModelState.AddModelError("email", "Username or password is Invalid");
            }

            if (ModelState.IsValid)
            {
                TempData["user"] = result[0]["first_name"];
                return RedirectToAction("Success");
            }

            return View();
        }
    }
}
