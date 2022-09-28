using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EnvironmentCrime.Models;

namespace EnvironmentCrime.Components
{
    public class ShowOneErrandViewComponent : ViewComponent
    {
        private ICrimeRepository repository;
        public ShowOneErrandViewComponent(ICrimeRepository repo)
        {
            repository = repo;
        }
        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            var ErrandDetail = await repository.GetErrandDetail(id);
            return View(ErrandDetail);
        }
    }
}
