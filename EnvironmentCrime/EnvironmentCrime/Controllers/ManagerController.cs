using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EnvironmentCrime.Models;

namespace EnvironmentCrime.Controllers
{
    public class ManagerController : Controller
    {
        private ICrimeRepository repository;

        public ManagerController(ICrimeRepository repo)
        {
            repository = repo;
        }

        public IActionResult Manager()
        {
            return View(repository);
        }
        public IActionResult CrimeManager(int id)
        {
            ViewBag.ID = id;
            return View(repository.Employees);
        }
    }
}
