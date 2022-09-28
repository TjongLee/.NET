using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using EnvironmentCrime.Infrastructure;
using EnvironmentCrime.Models;

namespace EnvironmentCrime.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var myErrand = HttpContext.Session.GetJson<Errand>("NewErrand");
            if (myErrand == null)
            {
                return View();
            }
            else
            {
                return View(myErrand);
            }
        }
        public IActionResult LogIn()
        {
            return View();
        }
    }
}
