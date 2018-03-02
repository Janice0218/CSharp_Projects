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
        public IActionResult Login(Login loginTry)
        {
            if (ModelState.IsValid)
            {
                var result = _context.Users.FirstOrDefault(u => u.email == loginTry.email);
                if (result == null)
                {
                    ModelState.AddModelError("email", "Email not found");
                    return View();
                }
                else
                {
                    var pwhasher = new PasswordHasher<Login>();
                    if (pwhasher.VerifyHashedPassword(loginTry, result.password, loginTry.password) ==
                        PasswordVerificationResult.Success)
                    {
                        HttpContext.Session.SetInt32("id", result.user_id);
                        return RedirectToAction("AccountHome");
                    }ModelState.AddModelError("email", "email or password combination is not valid");
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
        public IActionResult Register(UserViewModel newUser)
        {
            if (ModelState.IsValid)
            {
                if (_context.Users.Any(u => u.email == newUser.email))
                {
                    ModelState.AddModelError("email", "Email address is already registered to a user");
                    return View();
                }
                var pw = newUser.password;
                var pwhasher = new PasswordHasher<UserViewModel>();
                var hpw= pwhasher.HashPassword(newUser, pw);
                var safeUser = new User()
                {
                    email = newUser.email,
                    first_name = newUser.first_name,
                    last_name = newUser.last_name,
                    password = hpw
                };
                _context.Users.Add(safeUser);
                _context.SaveChanges();
                var id = newUser.user_id;
                HttpContext.Session.SetInt32("id", id);
                return RedirectToAction("AccountHome");
            }
            return View("Register", newUser);
            }


        public IActionResult AccountHome()
        {
            if (HttpContext.Session.GetInt32("id") == null)
            {
                return RedirectToAction("Login");
            }
            var userId = HttpContext.Session.GetInt32("id");
            var user = _context.Transactions.Where(t => t.Users_user_id == userId).ToList();
            ViewBag.Balance = user.Where(t => t.type == "deposit").Sum(t => t.amount) -
                      user.Where(t => t.type == "withdraw").Sum(t => t.amount);
            return View(new TransactionViewModel {Transactions = user});
        }

        [HttpPost]
        public IActionResult Transact(TransactionViewModel trans)
        {
            var newTrans = new Transaction()
            {
                type = trans.Transaction.type,
                amount = trans.Transaction.amount,
                timestamp = DateTime.Now,
                Users_user_id = (int) HttpContext.Session.GetInt32("id")
            };
            _context.Transactions.Add(newTrans);
            _context.SaveChanges();
            return RedirectToAction("AccountHome");
        }

        public IActionResult LogOut()
        {
            HttpContext.Session.Clear();
            TempData["logout"] = "You have been logged out";
            return RedirectToAction("Login");
        }

        
    }
}
