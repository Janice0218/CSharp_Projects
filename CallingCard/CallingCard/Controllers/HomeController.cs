using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Remotion.Linq.Clauses.ResultOperators;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CallingCard.Controllers
{
    public class HomeController : Controller
    {
        // GET: /<controller>/
        [HttpGet("{first}/{last}/{age}/{favColor}")]
        public IActionResult Index(string first, string last, string age, string favColor)
        {
            var data = new {firstName = first, LastName = last, age = age, FavoriteColor = favColor};
            return Json(data);
        }
    }
}
