using final_project.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace final_project.Data.Context
{
    // This class will translate Models into Database tables
    class final_projectDbContext : DbContext
    {
        // Per Model that we want to turn into a table
        // we add it as a Dbset

        DbSet<ShelterOne> Shelters { get; set; }
    }
}
