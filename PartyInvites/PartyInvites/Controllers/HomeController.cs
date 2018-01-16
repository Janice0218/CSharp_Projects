using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PartyInvites.Models;

namespace PartyInvites.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult RsvpForm()
        {

            return View();

        }
        [HttpPost]
        public IActionResult RsvpForm(GuestResponse response)
        {
            Repository.AddResponse(response);
            return View("Thanks", response);
        }

        public IActionResult ListResponses()
        {
            return View(Repository.Responses.Where(res => res.WillAttend == true));
        }

 
    }
}
