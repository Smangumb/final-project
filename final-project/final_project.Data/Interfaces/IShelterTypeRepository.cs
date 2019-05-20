using final_project.Domain.Model;
using System.Collections.Generic;
using System.Text;
using System;

namespace final_project.Data.Interfaces
{
    public interface IShelterTypeRepository
    {
        // Read
        ShelterType GetById(int id);
        ICollection<ShelterType> GetAll();
    }
}
