using final_project.Domain.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;


namespace final_project.Data.Context
{
    // DbContext -> represent a session to a db and provides API's
    // to communicate with db
    public class final_projectDbContext : IdentityDbContext<AppUser>
    {
        // Represents a collection (table) of a giving entity/model
        // They map to table by default

        public DbSet<ShelterOne> Animals { get; set; }
        public DbSet<ShelterType> ShelterTypes { get; set; }

        // Virtual method designed to be overriden
        // You can provide configuration information for the context
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Conntection strin gis divided in 3 elements
            // server - database - authentication
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=final_project;Trusted_Connection=true");
        }

        // We can manipulate the models
        // Add data to tables
        // Change the default relationships 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // base = IdentityDbContext
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ShelterType>().HasData(
                new ShelterType { Id = 1, Description = "Puppy" },
                new ShelterType { Id = 2, Description = "Adult" },
                new ShelterType { Id = 3, Description = "Senior" }
                );
        }
    }
}
