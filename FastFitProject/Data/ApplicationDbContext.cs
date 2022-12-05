using Fast_Fit_Final_Project.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace FastFitProject.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Members> Members { get; set; } // might have to delete this line
        //public DbSet<Shoe> Shoes { get; set; }
        

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
