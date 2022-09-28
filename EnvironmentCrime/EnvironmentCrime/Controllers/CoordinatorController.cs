using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EnvironmentCrime.Models;
using EnvironmentCrime.Infrastructure;

namespace EnvironmentCrime.Controllers
{
    public class CoordinatorController : Controller
    {
        private ICrimeRepository repository;

        public CoordinatorController(ICrimeRepository repo)
        {
            repository = repo;
        }
        public IActionResult Coordinator()
        {
            return View(repository);
        }
        public IActionResult CrimeCoordinator(int id)
        {
            ViewBag.ID = id;
            return View(repository.Departments);
        }
        public IActionResult ReportCrime()
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
        public IActionResult Thanks()
        {
            var myErrand = HttpContext.Session.GetJson<Errand>("NewErrand");
            repository.SaveErrand(myErrand);
            ViewBag.Ref = myErrand.RefNumber;

            HttpContext.Session.Remove("NewErrand");
            return View();
        }
        public IActionResult Validate(Errand errand)
        {
            HttpContext.Session.SetJson("NewErrand", errand);

            return View(errand);
        }
    }
}
