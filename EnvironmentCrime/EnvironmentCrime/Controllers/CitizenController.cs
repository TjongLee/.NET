using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EnvironmentCrime.Models;
using EnvironmentCrime.Infrastructure;

namespace EnvironmentCrime.Controllers
{
    public class CitizenController : Controller
    {
        private ICrimeRepository repository;

        public CitizenController(ICrimeRepository repo)
        {
            repository = repo; // Accessing the repository
        }

        public IActionResult Services()
        {
            return View();
        }

        public IActionResult FAQ()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }
        public IActionResult Citizen()
        {
            return View();
        }
        public IActionResult Thanks() // when the errand is validated the session is removed and the refence number is sent to the thanks view
        {
            var myErrand = HttpContext.Session.GetJson<Errand>("NewErrand");
            repository.SaveErrand(myErrand);
            ViewBag.Ref = myErrand.RefNumber;

            HttpContext.Session.Remove("NewErrand");
            return View();
        }
        public IActionResult Index()
        {
            var myErrand = HttpContext.Session.GetJson<Errand>("NewErrand"); // stores the errand in a variable
            if (myErrand == null) // if it didnt exist it will be null, meaning you havent entered a errand yet
            {
                return View(); // returns the empty view
            }
            else
            {
                return View(myErrand); // returns the view with the errand you created so you can edit it
            }
        }

        [HttpPost]
        public IActionResult Validate(Errand errand)
        {
            HttpContext.Session.SetJson("NewErrand", errand); // sets the value of NewErrand to the value you input
            return View(errand); // returns the view with the errend so the user can validate it
        }
    }
}
