using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using final_project.Domain.Model;

namespace final_project.Domain.Model
{
    public class ShelterOne
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Don't forget to add the Breed of the animal")]
        public string Breed { get; set; }

        [Required(ErrorMessage = "Don't forget to add the Gender of the animal")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Don't forget to add the Name of the animal")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Don't forget to add the Age of the animal")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Don't forget to add the Weight of the animal")]
        public int Weight { get; set; }

        [Required(ErrorMessage = "Don't forget to add the Color of the animal")]
        public string Color { get; set; }


        // Fully Defined Relationship
        [Display(Name = "Dog Type")]
        public int ShelterTypeId { get; set; }
        public ShelterType ShelterType { get; set; }

        // fully Defined Relationship for AppUser
        public string AppUserId { get; set; }
        public AppUser Admin { get; set; }
    }
}
