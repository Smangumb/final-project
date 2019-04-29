using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace final_project.Domain.Models
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
    }
}
