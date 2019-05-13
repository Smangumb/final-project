using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using final_project.Domain.Models;
using final_project.Service.Services;

namespace final_project.WebUI.Controllers
{
    public class ShelterOneController : Controller
    {
        private readonly IShelterService __shelterService;

        public ShelterOneController(IShelterService shelterService)
        {
            __shelterService = shelterService;
        }

        // property/index
        public IActionResult Index()
        {
            var shelters = __shelterService.GetAllShelters();
            return View(shelters);
        }

        // GET property/add
        [HttpGet]
        public IActionResult Add()
        {
            return View("Form"); // --> Add.cshtml, remaned to Form.cshtml
        }

        [HttpPost]
        public IActionResult Add(ShelterOne newShelter) // -> receive data from a HTML form
        {
            if (ModelState.IsValid) // all required fields are completed
            {
                __shelterService.Create(newShelter);
                return RedirectToAction(nameof(Index)); // -> Index();
            }

            return View("Form");
        }

        public IActionResult Detail(int id) // -> get id from URL
        {
            var shelter = __shelterService.GetById(id);

            return View(shelter);
        }

        public IActionResult Delete(int id)
        {
            var succeeded = __shelterService.Delete(id);

            if (!succeeded) // when delete fails (false)
                ViewBag.Error = "Sorry, the animal could not be deleted, try agaim later.";

            return RedirectToAction(nameof(Index));
        }

        // property/edit/1
        public IActionResult Edit(int id) // --> get id from URL 
        {
            var shelter = __shelterService.GetById(id);

            return View("Form", shelter); // Edit.cshtml, remaned to Form.cshtml
        }

        [HttpPost]
        // get id from URL
        // get updatedProperty from FORM
        public IActionResult Edit(int id, ShelterOne updatedShelter)
        {
            if (ModelState.IsValid)
            {
                __shelterService.Update(updatedShelter);

                return RedirectToAction(nameof(Index));
            }

            return View("Form", updatedShelter); // By passing updatedShelter
                                                 // We trigger the logic
                                                 // for Edit within the Form.cshtml
        }
    }
}