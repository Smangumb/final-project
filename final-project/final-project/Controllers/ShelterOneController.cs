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
        private List<ShelterOne> Animals = new List<ShelterOne>
        {
            new ShelterOne { Id = 1, Breed = "Mix Terrier", Gender = "Male", Name = "Milo", Age = 9, Weight = 100, Color = "Brown"},
            new ShelterOne { Id = 2, Breed = "Maltipoo", Gender = "Male", Name = "Banks", Age = 1, Weight = 20, Color = "White & Black"},
        };
        public IActionResult Index()
        {
            return View(Animals);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(ShelterOne newShelter)
        {
            Animals.Add(newShelter);

            return View(nameof(Index), Animals);
        }

        public IActionResult Detail(int id)
        {

            var shelter = Animals.Single(p => p.Id == id);

            return View(shelter);
        }

        public IActionResult Delete(int id)
        {
            var shelter = Animals.Single(p => p.Id == id);

            Animals.Remove(shelter);

            return View(nameof(Index), Animals);
        }
    }
}