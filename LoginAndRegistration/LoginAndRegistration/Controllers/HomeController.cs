using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LoginAndRegistration.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;


namespace LoginAndRegistration.Controllers
{
    public class HomeController : Controller
    {
        private DBConnector _dbConnector;

        public HomeController(DBConnector dbConnector)
        {
            _dbConnector = dbConnector;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(User user)
        {
            //get submitted data form and validate
            //if ok
            if (ModelState.IsValid)
            {
                string emailQuery = $"select id from users where email='{user.email}'";
                var result = _dbConnector.Query(emailQuery);
                if (result.Count > 0)
                {
                    ModelState.AddModelError("email", "email is already in use");
                }
                if (ModelState.IsValid)
                {
                    //hash password
                    var hasher = new PasswordHasher<User>();
                    var hashPassword = hasher.HashPassword(user, user.password);

                    //save to DB
                    var query =
                        $"Insert into users(first_name, last_name, email, password, created_at, updated_at) values('{user.first_name}','{user.last_name}', '{user.email}','{hashPassword}', now(), now())";
                    _dbConnector.Execute(query);
                    //
                    var addedUser = _dbConnector.Query($"Select * from users where id=LAST_INSERT_ID()");
                    TempData["user"] = addedUser[0]["first_name"];
                    return View("Success");
                }

            } 

            return View("Index" , user);
        }

        public IActionResult Success() => View();

        [HttpGet]
        public IActionResult Login() => View();

        [HttpPost]
        public IActionResult LogIn(LoginUser user)
        {
            if (ModelState.IsValid)
            {
                var query = $"Select * from users where email='{user.email}'";
                var result = _dbConnector.Query(query).FirstOrDefault();
                
                if (result == null)
                {
                    ModelState.AddModelError("email", "Invalid email/password");
                }
                else
                {
                    string pw = result["password"].ToString();
                    var hasher = new PasswordHasher<LoginUser>();
                    if(hasher.VerifyHashedPassword(user, pw, user.password) == PasswordVerificationResult.Failed)
                    {
                        ModelState.AddModelError("email", "Invalid email/password");
                    }

                    
                }
                if (ModelState.IsValid)
                {
                    HttpContext.Session.SetInt32("id", (int)result["id"]);
                    TempData["user"] = result["first_name"];
                    return RedirectToAction("Success");
                }

            }

            return View();
        }
    }
}
