using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using final_project.Domain.Models;

namespace final_project.WebUI.Controllers
{
    public class ShelterOneController : Controller
    {
        private List<ShelterOne> Animals = new List<ShelterOne>
        {
            new ShelterOne { Id = 1, Breed = "Mix Terrier", Gender = "Male", Name = "Milo", Age = 9, Weight = 100, Color = "Brown"},
            new ShelterOne { Id = 2, Breed = "Maltipoo", Gender = "Male", Name = "Banks", Age = 1, Weight = 25, Color = "White & Black"},
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
            if (ModelState.IsValid)
            {
                Animals.Add(newShelter);

                return View(nameof(Index), Animals);
            }

            return View("Form");
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

        // shelter/edit/1
        public IActionResult Edit(int id) // --> get id from URL
        {
            var animal = Animals.Single(p => p.Id == id);

            return View("Form", animal);
        }

        [HttpPost]
        public IActionResult Edit(int id, ShelterOne updatedAnimal)
        {
            if (ModelState.IsValid)
            {
                var OldAnimal = Animals.Single(p => p.Id == id);

                OldAnimal.Breed = updatedAnimal.Breed;
                OldAnimal.Gender = updatedAnimal.Gender;
                OldAnimal.Name = updatedAnimal.Name;
                OldAnimal.Age = updatedAnimal.Age;
                OldAnimal.Weight = updatedAnimal.Weight;
                OldAnimal.Color = updatedAnimal.Color;

                return View(nameof(Index), Animals);
            }
            return View("Form", updatedAnimal);
        }
    }
}