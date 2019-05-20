using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using final_project.Domain.Model;
using final_project.Service.Services;
using final_project.Service.Service;

namespace final_project.WebUI.Controllers
{
    public class ShelterOneController : Controller
    {
        private const string SHELTERTYPES = "ShelterTypes";

        private readonly IShelterService __shelterService;
        private readonly IShelterTypeService _shelterTypeService;

        public ShelterOneController(IShelterService shelterService, IShelterTypeService shelterTypeService)
        {
            __shelterService = shelterService;
            _shelterTypeService = shelterTypeService;
        }

        // property/index
        public IActionResult Index()
        {
            // check if got any error in TempData
            if (TempData["Error"] != null)
            {
                // Pass that error to the ViewData, because
                // we are communicating between action and view
                ViewData.Add("Error", TempData["Error"]);
            }
            var shelters = __shelterService.GetAllShelters();
            return View(shelters);
        }

        // GET property/add
        [HttpGet]
        public IActionResult Add()
        {
            GetShelterTypes();
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

            GetShelterTypes();
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
                // Using tempdata - because we are communicating
                // between actions - from Delete to Index
                TempData.Add("Error", "Sorry, the property could not be deleted, try again later.");

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

        private void GetShelterTypes()
        {
            var shelterTypes = _shelterTypeService.GetAll();
            ViewData.Add(SHELTERTYPES, shelterTypes);
        }
    }
}