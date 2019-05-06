using final_project.Data.Interfaces;
using final_project.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace final_project.Service.Services
{
    public interface IShelterService
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

    public class PropertyService : IShelterService
    {
        private readonly IShelterRepository _shelterRepository; //-> null

        // Added a dependency to the constructor
        public PropertyService(IShelterRepository shelterRepository)
        {
            _shelterRepository = shelterRepository; //-> not be null anymore
        }
        public ICollection<ShelterOne> GetAllShelters()
        {
            return _shelterRepository.GetAllShelters();
        }

        public ShelterOne Create(ShelterOne newShelter)
        {
            return _shelterRepository.Create(newShelter); // Create() is from Repository
        }

        public bool Delete(int id)
        {
            return _shelterRepository.Delete(id);
        }

        public ShelterOne GetById(int id)
        {
            return _shelterRepository.GetById(id);
        }

        public ShelterOne Update(ShelterOne updatedProperty)
        {
            return _shelterRepository.Update(updatedProperty);
        }
    }
}
