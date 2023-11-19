using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using StudentFeePayment.Entities.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentFeePayment.Entities
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            :base(options) { }

        public DbSet<Student> Students { get; set; }
        public DbSet<FeePayment> FeePayments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var allEntities = modelBuilder.Model.GetEntityTypes();

            // Configure Shadow properties for each entity in the model
            foreach (var entity in allEntities)
            {
                entity.AddProperty("CreatedDate", typeof(DateTime));
                entity.AddProperty("UpdatedDate", typeof(DateTime));

                entity.AddProperty("CreatedBy", typeof(string));
                entity.AddProperty("UpdatedBy", typeof(string));
            }

            // Make student number unique for each student
            modelBuilder.Entity<Student>()
                .HasIndex(u => u.StudentNumber)
                .IsUnique();
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entries = ChangeTracker
            .Entries()
            .Where(e =>
                e.State == EntityState.Added
                || e.State == EntityState.Modified);

            foreach (var entityEntry in entries)
            {
                // Set Shadow properties values
                entityEntry.Property("UpdatedDate").CurrentValue = DateTime.Now;
                entityEntry.Property("UpdatedBy").CurrentValue = "system user";

                if (entityEntry.State == EntityState.Added)
                {
                    entityEntry.Property("CreatedDate").CurrentValue = DateTime.Now;
                    entityEntry.Property("CreatedBy").CurrentValue = "system user";
                }
            }

            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
