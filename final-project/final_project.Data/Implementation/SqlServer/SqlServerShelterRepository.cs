using final_project.Data.Context;
using final_project.Data.Interfaces;
using final_project.Domain.Models;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace final_project.Data.Implementation.SqlServer
{
    public class SqlServerShelterRepository : IShelterRepository
    {
        public ShelterOne GetById(int id)
        {
            using (var context = new final_projectDbContext())
            {
                // SQL -> Database look for table Properties
                var shelter = context.Animals.Single(p => p.Id == id);
                return shelter;
            }
        }

        public ICollection<ShelterOne> GetAllShelters()
        {
            using (var context = new final_projectDbContext())
            {
                // DbSet != ICollection
                return context.Animals.ToList(); // Now it is ICollection
            }
        }

        public ShelterOne Create(ShelterOne newShelter)
        {
            using (var context = new final_projectDbContext())
            {
                context.Animals.Add(newShelter);
                context.SaveChanges();

                return newShelter; // newProperty.Id will be populated with new DB value
            }
        }

        public ShelterOne Update(ShelterOne updatedShelter)
        {
            using (var context = new final_projectDbContext())
            {
                // find the old entity
                var oldShelter = GetById(updatedShelter.Id);

                // update each entity properties / get;set;
                context.Entry(oldShelter).CurrentValues.SetValues(updatedShelter);

                // save changes
                context.SaveChanges();

                return oldShelter; // To ensure that the save happened
            }
        }

        public bool Delete(int id)
        {
            using (var context = new final_projectDbContext())
            {
                // Find what we are going to delete
                var shelterToBeDeleted = GetById(id);

                // delete
                context.Animals.Remove(shelterToBeDeleted);

                // save changes
                context.SaveChanges();

                // check if entity/model exist
                if (GetById(id) == null)
                {
                    return true;
                }

                return false;
            }
        }
    }
}
