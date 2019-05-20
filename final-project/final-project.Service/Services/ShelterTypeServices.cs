using System;
using System.Collections.Generic;
using System.Text;
using final_project.Data.Interfaces;
using final_project.Domain.Model;

namespace final_project.Service.Service
{
    public interface IShelterTypeService
    {
        // Read
        ShelterType GetById(int id);
        ICollection<ShelterType> GetAll();
    }

    public class ShelterTypeServices : IShelterTypeService
    {
        private readonly IShelterTypeRepository _shelterTypeRepository;

        public ShelterTypeServices(IShelterTypeRepository shelterTypeRepository)
        {
            _shelterTypeRepository = shelterTypeRepository;
        }

        public ICollection<ShelterType> GetAll()
        {
            return _shelterTypeRepository.GetAll();
        }

        public ShelterType GetById(int id)
        {
            return _shelterTypeRepository.GetById(id);
        }
    }
}
