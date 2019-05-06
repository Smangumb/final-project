using final_project.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace final_project.Data.Context
{
    // This class will translate Models into Database tables
    public class final_projectDbContext : DbContext
    {
        // Per Model that we want to turn into a table
        // we add it as a Dbset

        public DbSet<ShelterOne> Animals { get; set; }

        // Virtual method designed to be overriden
        // You can provide configuration information for the context
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Conntection strin gis divided in 3 elements
            // server - database - authentication
            optionsBuilder.UseSqlServer(@"Server=(locladb)\mssqllocaldb;Database=final_project;Trusted_Connection=true");
        }
    }
}
