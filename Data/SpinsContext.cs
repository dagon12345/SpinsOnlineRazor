using Microsoft.EntityFrameworkCore;
using SpinsOnlineRazor.Models.RedesignModels;
using SpinsOnlineRazor.Models.RedesignModels.ComplexModels;

namespace SpinsOnlineRazor.Data
{
    public class SpinsContext : DbContext
    {
        public SpinsContext(DbContextOptions<SpinsContext> options)
            : base(options)
        {
        }
        //Need nat mugamit nan plural variables para ma match an dbset name

        public DbSet<ViewModelBeneficiary> viewModelBeneficiaries { get; set; }
        public DbSet<Beneficiary> Beneficiaries { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Province> Provinces { get; set; }
        public DbSet<Municipality> Municipalities { get; set; }
        public DbSet<Barangay> Barangays { get; set; }
        public DbSet<IdentificationType> IdentificationTypes { get; set; }
        public DbSet<HealthStatus> HealthStatuses { get; set; }
        public DbSet<Sex> Sexes { get; set; }
        public DbSet<Maritalstatus> Maritalstatuses { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<Validationform> Validationforms { get; set; }

        public DbSet<Assessment> Assessments { get; set; }

        /*Calls OnModelCreating. OnModelCreating:
        Is called when SchoolContext has been initialized, but before the model has been locked down and used to initialize the context.
        Is required because later in the tutorial the Beneficiary entity will have references to the other entities.*/
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           /*An isa ka masterlists is ra ka beneficary kay bawal dabo, pero
           masuyod sija sa masterlists which is dabo sila Beneficiary*/

           modelBuilder.Entity<Beneficiary>().ToTable("Beneficiary");
        //   modelBuilder.Entity<Beneficiary>()
        //   .HasOne(p => p.Validationform)
        //   .WithMany(p => p.Beneficiaries)
        //   .HasForeignKey( p => p.BeneficiaryID)
        //   .IsRequired(false);

           modelBuilder.Entity<Region>().ToTable("Region");
            modelBuilder.Entity<IdentificationType>().ToTable("IdentificationType");
            modelBuilder.Entity<HealthStatus>().ToTable("HealthStatus");
             modelBuilder.Entity<Province>().ToTable("Province");
              modelBuilder.Entity<Municipality>().ToTable("Municipality");
               modelBuilder.Entity<Barangay>().ToTable("Barangay");
               modelBuilder.Entity<Sex>().ToTable("Sex");
               modelBuilder.Entity<Maritalstatus>().ToTable("Maritalstatus");
                modelBuilder.Entity<Status>().ToTable("Status");

                modelBuilder.Entity<Validationform>().ToTable("Validationform");
                 modelBuilder.Entity<Assessment>().ToTable("Assessment");
                // .HasMany(p => p.Beneficiaries)
                // .WithOne(p => p.Validationform)
                // .HasForeignKey(p => p.BeneficiaryID)
                // .IsRequired(false);



            
        }

        /*NOTE: A foreign key constraint fail usually means that the code is trying to insert something 
        into table b with data that requires a field that must already exist in table a.*/
    }
}
