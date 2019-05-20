using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using final_project.Domain.Model;

namespace final_project.Domain.Model
{
    public class ShelterType
    {
        public int Id { get; set; } // PK in DB table

        [Required] // Make sure that any entry contains a description
        public string Description { get; set; }
    }
}
