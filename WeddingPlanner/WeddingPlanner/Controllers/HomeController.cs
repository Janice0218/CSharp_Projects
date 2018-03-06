using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WeddingPlanner.Models;


namespace WeddingPlanner.Controllers
{
    public class HomeController : Controller
    {
        private MyDbContext _context;

        public HomeController(MyDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Register() => View();

        public IActionResult Register(User newUser)
        {
            _context.Users.Add(newUser);
            _context.SaveChanges();
            HttpContext.Session.SetInt32("id", newUser.UserId);
            return RedirectToAction("Wedding");
        }

        

        public IActionResult CreateWedding(Wedding d)
        {
            var wedding = new Wedding()
            {
                AFirstName = d.AFirstName,
                ALastName = d.ALastName,
                BFirstName = d.BFirstName,
                BLastName = d.BLastName,
                UserId = 0,
                Date = d.Date
            };
            _context.Weddings.Add(wedding);
            _context.SaveChanges();
            var wedId = wedding.WeddingId;
            HttpContext.Session.SetInt32("WeddingId", wedId);
            return RedirectToAction("Wedding");
        }

        public IActionResult Wedding()
        {
            var wedId = HttpContext.Session.GetInt32("WeddingId");
            var result = _context.Weddings.FirstOrDefault(d => d.WeddingId == wedId);
            if (result == null)
            {
                return View(new Wedding());
            } 
         return View(result);}
        

        [HttpGet]
        public IActionResult Dashboard()
        {
            var result = _context.Weddings;
            return View(result);

        }

        public IActionResult GuestList()
        {
           var guests= _context.Guests.Where(g => g.WeddingId == HttpContext.Session.GetInt32("WeddingId")).ToList();
            return View(guests);
        }
    }
}
