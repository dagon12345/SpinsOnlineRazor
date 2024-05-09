using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SpinsOnlineRazor.Areas.Identity.Data;
using SpinsOnlineRazor.Models.RedesignModels;
using SpinsOnlineRazor.Models.RedesignModels.ComplexModels;

namespace SpinsOnlineRazor.Data
{
    public class SpinsContext : IdentityDbContext<SpinsUser>
    {
        //New code for delete, instead of remove update it.

        public SpinsContext(DbContextOptions<SpinsContext> options)
            : base(options)
        {
        }

        //Override the SaveChanges for Delete instead of physical delete we make this and soft delete.

        public override int SaveChanges()
        {
            HandleBeneficiaryDelete();
            // foreach (var entityEntry in ChangeTracker.Entries<Beneficiary>()) // Detects changes automatically
            // {
            //     if (entityEntry.State == EntityState.Added)
            //     {
            //         entityEntry.Entity.LastName = "ajcvickers";
            //         entityEntry.Entity.FirstName = "ajcvickers";
            //     }
            // }
            return base.SaveChanges();
        }
        private void HandleBeneficiaryDelete()
        {
            var entities = ChangeTracker.Entries()
                                .Where(e => e.State == EntityState.Deleted);
            foreach (var entity in entities)
            {
                if (entity.Entity is Beneficiary)
                {
                    entity.State = EntityState.Modified;
                    var bene = entity.Entity as Beneficiary;
                    bene.IsDeleted = true;
                    bene.DeletedDate = DateTime.UtcNow;
                    bene.DeletedBy = "The User";

                }
            }
        }
        //Need nat mugamit nan plural variables para ma match an dbset name

        //public DbSet<ViewModelBeneficiary> viewModelBeneficiaries { get; set; }
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

        public DbSet<Log> Logs { get; set; }

        /*Calls OnModelCreating. OnModelCreating:
        Is called when SchoolContext has been initialized, but before the model has been locked down and used to initialize the context.
        Is required because later in the tutorial the Beneficiary entity will have references to the other entities.*/
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            /*An isa ka masterlists is ra ka beneficary kay bawal dabo, pero
            masuyod sija sa masterlists which is dabo sila Beneficiary*/

            modelBuilder.Entity<Beneficiary>().ToTable("Beneficiary");
            modelBuilder.Entity<Beneficiary>().HasQueryFilter(b => !b.IsDeleted); // This is to filter if the IsDeleted was true this is to use the do not repeart yourself code pattern
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
            modelBuilder.Entity<Log>().ToTable("Log");
            // .HasMany(p => p.Beneficiaries)
            // .WithOne(p => p.Validationform)
            // .HasForeignKey(p => p.BeneficiaryID)
            // .IsRequired(false);




        }

        /*NOTE: A foreign key constraint fail usually means that the code is trying to insert something 
        into table b with data that requires a field that must already exist in table a.*/
    }
}
