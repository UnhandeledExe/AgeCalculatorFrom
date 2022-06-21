using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AgeCalculatorFrom.Models;
using Microsoft.AspNetCore.Mvc;

namespace AgeCalculatorFrom.Data
{
    public class PeopleContext : DbContext
    {
        public PeopleContext (DbContextOptions<PeopleContext> options)
            : base(options)
        {
        }

        public DbSet<Person> People { get; set; }
        public DbSet<City> Cities { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>().ToTable("Person");
            modelBuilder.Entity<City>().ToTable("City");
        }


    }
}
