using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EnvironmentCrime.Models;

namespace EnvironmentCrime.Controllers
{
    public class InvestigatorController : Controller
    {
        private ICrimeRepository repository;

        public InvestigatorController(ICrimeRepository repo)
        {
            repository = repo;
        }
        public IActionResult Investigator()
        {
            return View(repository);
        }
        public IActionResult CrimeInvestigator(int id)
        {
            ViewBag.ID = id;
            return View(repository.ErrandStatuses);
        }
    }
}
