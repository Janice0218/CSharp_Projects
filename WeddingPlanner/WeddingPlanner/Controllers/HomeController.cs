using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        public IActionResult NewWedding() => View();
        
        [HttpPost]
        public IActionResult CreateWedding(Wedding w)
        {
//            var wedding = new Wedding()
//            {
//                AFirstName = d.AFirstName,
//                ALastName = d.ALastName,
//                BFirstName = d.BFirstName,
//                BLastName = d.BLastName,
//                UserId = 0,
//                Date = d.Date
//            };
            _context.Weddings.Add(w);
            _context.SaveChanges();
            var wedId = w.WeddingId;
            HttpContext.Session.SetInt32("WeddingId", wedId);
            return RedirectToAction("Wedding");
        }

        public IActionResult Wedding(int wedId)
        {
            if (wedId == 0)
            {
                wedId = (int)HttpContext.Session.GetInt32("WeddingId");
            }
            else { HttpContext.Session.SetInt32("WeddingId", wedId);}
            var result = _context.Weddings.Include(guest=> guest.Guests).FirstOrDefault(d => d.WeddingId == wedId);
            if (result == null)
            {
                return View();
            } 
         return View(result);}
        

        [HttpGet]
        public IActionResult Dashboard()
        {
            var result = _context.Weddings.ToList();
            return View(result);

        }

        public IActionResult NewGuest() => View();

        [HttpPost]
        public IActionResult AddGuest(Guest g)
        {
            var wedId = (int) HttpContext.Session.GetInt32("WeddingId");
            var guest = new Guest()
            {
                AFirstName = g.AFirstName,
                ALastName = g.ALastName,
                BFirstName = g.BFirstName,
                BLastName = g.BLastName,
                IsAttending = g.IsAttending,
                WeddingId = wedId
            };
            _context.Guests.Add(guest);
            _context.SaveChanges();
            return RedirectToAction("GuestList");

        }
        public IActionResult GuestList()
        {
           var guests= _context.Guests.Where(g => g.WeddingId == HttpContext.Session.GetInt32("WeddingId")).OrderBy(g=> g.ALastName).ToList();
            return View(guests);
        }
    }
}
