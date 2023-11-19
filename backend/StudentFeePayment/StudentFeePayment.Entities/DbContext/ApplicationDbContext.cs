using Microsoft.AspNetCore.Http.HttpResults;
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

            //Seed sample data for Student entities

            //Students
            modelBuilder.Entity<Student>().HasData(new
            {
                Id = 1,
                FirstName = "Jahnzab",
                LastName = "Ashraf",
                Email = "jahanzab@live.com",
                Phone = "+92 334 6168078",
                Address = "Islamabad, Pakistan",
                DOB = new DateTime(),
                StudentNumber = "00001",
                Grade = "First",
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                CreatedBy = "system user",
                UpdatedBy = "system user"
            }, new
            {
                Id = 2,
                FirstName = "John",
                LastName = "Doe",
                Email = "john.doe@live.com",
                Phone = "+1 (555) 555-1234",
                Address = "NY, USA",
                DOB = new DateTime(),
                StudentNumber = "00002",
                Grade = "Second",
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                CreatedBy = "system user",
                UpdatedBy = "system user"
            });

            //Fee Payments
            modelBuilder.Entity<FeePayment>().HasData(new
            {
                Id = 1,
                FeeAmount = 102.21M,
                IsPaid = true,
                PaidDate = DateTime.Now,
                FeeYear = 2023,
                Remarks = "Fee paid",
                StudentId = 1,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                CreatedBy = "system user",
                UpdatedBy = "system user"
            }, new
            {
                Id = 2,
                FeeAmount = 90.50M,
                IsPaid = true,
                PaidDate = DateTime.Now,
                FeeYear = 2023,
                Remarks = "Fee paid",
                StudentId = 2,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                CreatedBy = "system user",
                UpdatedBy = "system user"
            });

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
