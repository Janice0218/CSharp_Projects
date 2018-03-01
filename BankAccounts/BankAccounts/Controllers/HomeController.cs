using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using BankAccounts.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;


namespace BankAccounts.Controllers
{
    public class HomeController : Controller
    {
        private BankingDbContext _context;

        public HomeController(BankingDbContext context)
        {
            _context = context;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            var result= _context.Users.FirstOrDefault(u => u.email == email);
            if (result == null)
            {
                ModelState.AddModelError("email", "Email not found");
            }
            else
            {
                if (result.password == password)
                {
                    HttpContext.Session.SetInt32("id", result.user_id);
                }
            }
            return RedirectToAction("AccountHome");
        }

        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(User newUser)
        {
            _context.Users.Add(newUser);
            _context.SaveChanges();
            var id = newUser.user_id;

            return RedirectToAction("AccountHome");
        }

        public IActionResult AccountHome()
        {
            if (HttpContext.Session.GetInt32("id") == null
            )
            {
                return RedirectToAction("Login");
            }

            var userId = HttpContext.Session.GetInt32("id");
            var user = _context.Transactions.Where(t => t.Users_user_id == userId).ToList();
            return View(user);
        }
    }
}
