using final_project.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace final_project.Data.Interfaces
{
    public interface IShelterRepository
    {
        // Read
        ShelterOne GetById(int id);
        ICollection<ShelterOne> GetAllShelters();

        // Create
        ShelterOne Create(ShelterOne newShelter);

        // Update
        ShelterOne Update(ShelterOne updatedShelter);

        // Delete
        bool Delete(int id);
    }
}
