using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DbConnection;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TheWall.Models;



namespace TheWall.Controllers
{
    public class HomeController : Controller
    {
        private DbConnector _dbConnector;

        public HomeController(DbConnector dbConnector)
        {
            _dbConnector = dbConnector;
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(ReturningUser user)
        {
            if (ModelState.IsValid)
            {
                var emailQuery = $"Select * from users where email='{user.email}'";
                var result = _dbConnector.Query(emailQuery).FirstOrDefault();
                if (result == null)
                {
                    ModelState.AddModelError("email", "Invalid email/password");
                }
                else
                {
                    var hasher = new PasswordHasher<ReturningUser>();
                    var pw = result["password"].ToString();
                    if (hasher.VerifyHashedPassword(user, pw, user.password) == PasswordVerificationResult.Failed)
                    {
                        ModelState.AddModelError("email", "Invalid email/password");
                    }
                }

                if (ModelState.IsValid)
                {
                    HttpContext.Session.SetInt32("id", (int)result["id"]);
                    RedirectToAction("Show");
                    return RedirectToAction("Show");
                }
            }
            return View();
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(User info)
        {
            if (ModelState.IsValid)
            {
                var hasher = new PasswordHasher<User>();
                var hashedPassword =  hasher.HashPassword(info, info.password);
                _dbConnector.Execute(
                    $"INSERT INTO users (first_name, last_name, email, password, created_at, updated_at) values('{info.first_name}', '{info.last_name}','{info.email}', '{hashedPassword}', now(),now())");
                var addedUser = _dbConnector.Query(@"Select*from users where id=LAST_INSERT_ID()");
                int userID = Convert.ToInt32(addedUser[0]["id"]);
                string name = addedUser[0]["first_name"].ToString();
                HttpContext.Session.SetInt32("id", userID);
                HttpContext.Session.SetString("name", name);
                TempData["id"] = userID;
                return RedirectToAction("Show");
            }

            return View(info);
        }

        public IActionResult Show()
        {
            var messages = _dbConnector.Query(
                $"select messages.*, users.first_name, users.last_name from messages join users as users on messages.user_id=users.id");
            var comments =  _dbConnector.Query(
                $"select comments.*, users.first_name, users.last_name from comments join users as users on comments.user_id=users.id");

            return View(new WallViewModel {Comments = comments, Messages = messages});

        }

        [HttpGet]
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

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var msgQuery = $"SELECT * FROM  MESSAGES WHERE id='{id}'";
            var result = _dbConnector.Query(msgQuery).FirstOrDefault();

            return View(new Message {message = result["message"].ToString(), id = (int)result["id"]});
        }

        [HttpPost]
        public IActionResult Edit(Message msg)
        {
            var updQuery = $"UPDATE messages SET message='{msg.message}' WHERE id='{msg.id}'";
            _dbConnector.Execute(updQuery);
            return RedirectToAction("Show");
        }

        [HttpGet]
        public IActionResult CreateComment(int id)
        {
            return View(new Comment{ message_id = id});
        }

        [HttpPost]
        public IActionResult CreateComment(string comment, int message_id)
        {
            var userId = HttpContext.Session.GetInt32("id");
            string commentQuery =
                $"INSERT INTO comments(comment, user_id, message_id, created_at, updated_at) VALUES ('{comment}', {userId}, {message_id}, now(), now())";
            _dbConnector.Execute(commentQuery);
            return RedirectToAction("Show");
        }
    }
}
