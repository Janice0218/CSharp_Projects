using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Restauranter.Models;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Restauranter.Controllers
{
    public class HomeController : Controller
    {
        private RestDbContext _dbAccess;

        public HomeController(RestDbContext dbAccess)
        {
            _dbAccess = dbAccess;
        }

        public IActionResult Index() => View();

        public IActionResult Reviews()
        {
            List<Restaurant> result = _dbAccess.Restaurants.OrderByDescending(r=>r.visit_date).ToList();
            return View(result);
        }

        [HttpPost]
        public IActionResult Create(Restaurant newreview)
        {
            _dbAccess.Restaurants.Add(newreview);
            _dbAccess.SaveChanges();
            return RedirectToAction("Reviews");

        }

    }
}
