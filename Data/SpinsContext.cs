using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SpinsOnlineRazor.Models.RedesignModels;
using SpinsOnlineRazor.Models.RedesignModels.ComplexModels;

namespace SpinsOnlineRazor.Data
{
    public class SpinsContext : DbContext
    {
        public SpinsContext (DbContextOptions<SpinsContext> options)
            : base(options)
        {
        }
        //Need nat mugamit nan plural variables para ma match an dbset name
        public DbSet<Beneficiary> Beneficiaries { get; set; }
        public DbSet<Masterlist> Masterlists { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Province> Provinces { get; set; }
        public DbSet<Municipality> Municipalities { get; set; }
        public DbSet<Barangay> Barangays { get; set; }
        public DbSet<Sex> Sexes { get; set; }
        public DbSet<Maritalstatus> MaritalStatuses { get; set; }
        public DbSet<Validationform> Validationforms { get; set; }
        public DbSet<Assessment> Assessments { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<IdentificationType> IdentificationTypes { get; set; }
        public DbSet<HealthStatus> HealthStatuses { get; set; }

/*Calls OnModelCreating. OnModelCreating:
Is called when SchoolContext has been initialized, but before the model has been locked down and used to initialize the context.
Is required because later in the tutorial the Beneficiary entity will have references to the other entities.*/
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Beneficiary>().ToTable("Beneficiary");
            modelBuilder.Entity<Masterlist>().ToTable("Masterlist");
            modelBuilder.Entity<Region>().ToTable("Region");
            modelBuilder.Entity<Province>().ToTable("Province");
            modelBuilder.Entity<Municipality>().ToTable("Municipality");
            modelBuilder.Entity<Barangay>().ToTable("Barangay");
            modelBuilder.Entity<Sex>().ToTable("Sex");
            modelBuilder.Entity<Maritalstatus>().ToTable("MaritalStatus");
            modelBuilder.Entity<Validationform>().ToTable("Validationform");
            modelBuilder.Entity<Assessment>().ToTable("Assessment");
            modelBuilder.Entity<Status>().ToTable("Status");
            modelBuilder.Entity<IdentificationType>().ToTable("IdentificationType");
            modelBuilder.Entity<HealthStatus>().ToTable("HealthStatus");
             
        }

        /*NOTE: A foreign key constraint fail usually means that the code is trying to insert something 
        into table b with data that requires a field that must already exist in table a.*/
    }
}
