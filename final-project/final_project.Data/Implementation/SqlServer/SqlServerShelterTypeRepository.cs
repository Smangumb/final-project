using final_project.Data.Context;
using final_project.Data.Interfaces;
using final_project.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace final_project.Data.Implementation.SqlServer
{
    public class SqlServerShelterTypeRepository : IShelterTypeRepository
    {
        public ICollection<ShelterType> GetAll()
        {
            using (var context = new final_projectDbContext())
            {
                return context.ShelterTypes.ToList();
            }
        }

        public ShelterType GetById(int id)
        {
            using (var context = new final_projectDbContext())
            {
                var shelterType = context.ShelterTypes.SingleOrDefault(pt => pt.Id == id);
                return shelterType;
            }
        }
    }
}
