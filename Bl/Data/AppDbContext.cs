using Domains.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLib.Data
{
    public class AppDbContext:DbContext
    {
        public virtual DbSet<TbPractitioner>TbPractitioners { get; set; }
        public virtual DbSet<TbCountry>TbCountries { get; set; }
        public virtual DbSet<TbPerson>TbPeople { get; set; }
        public virtual DbSet<TbPractitionerCase>TbPractitionerCases { get; set; }
        public virtual DbSet<TbCaseType> TbCaseTypes { get; set; }
        public virtual DbSet<TbPractitionerSpec> TbPractitionerSpecs{ get; set; }

        public AppDbContext()
        {

        }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {

            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }

    
    }
}

