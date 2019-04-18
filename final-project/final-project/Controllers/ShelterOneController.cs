using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using final_project.Models.Model;

namespace final_project.WebUI.Controllers
{
    public class ShelterOneController : Controller
    {
        private List<ShelterOne> Properties = new List<ShelterOne>();
        public IActionResult Index()
        {
            return View(Properties);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(ShelterOne newShelter)
        {
            Properties.Add(newShelter);

            return View(nameof(Index), Properties);
        }
    }
}