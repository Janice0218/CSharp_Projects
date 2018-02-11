using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DbConnection;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TheWall.Models;


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
            return RedirectToAction("Show");
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(Users info)
        {
            _dbConnector.Execute(
                $"INSERT INTO users (first_name, last_name, email, password, created_at, updated_at) values('{info.first_name}', '{info.last_name}','{info.email}', '{info.password}', now(),now())");
            var addedUser = _dbConnector.Query(@"Select*from users where id=LAST_INSERT_ID()");
            int userID = Convert.ToInt32(addedUser[0]["id"]);
            string name = addedUser[0]["first_name"].ToString();
            HttpContext.Session.SetInt32("id", userID );
            HttpContext.Session.SetString("name", name);
            TempData["id"] = userID;
            return RedirectToAction("Show");
        }

        public IActionResult Show()
        {
            ViewBag.name =HttpContext.Session.GetString("name");
            ViewBag.id =HttpContext.Session.GetInt32("id");
            var result =_dbConnector.Query(
                $"select messages.*, users.first_name, users.last_name from messages join users as users on messages.user_id = users.id");
            return View(result);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Message msg)
        {
            var userId = HttpContext.Session.GetInt32("id");
            var query =
                $"INSERT INTO messages(message, user_id, created_at, updated_at) VALUES ('{msg.message}', {userId}, now(),now())";
            _dbConnector.Execute(query);
            return RedirectToAction("Show");
        }
    }
}
