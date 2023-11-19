using Microsoft.EntityFrameworkCore;
using StudentFeePayment.Entities;
using StudentFeePayment.Entities.Models.Domain;
using StudentPayment.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentPayment.Repository
{
    public class FeePaymentRepository : RepositoryBase<FeePayment>, IFeePaymentRepository
    {
        private readonly ApplicationDbContext dbContext;

        public FeePaymentRepository(ApplicationDbContext dbContext)
            : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public void CreateFeePayment(FeePayment feePayment)
        {
            Student obj = dbContext.Students.First(s  => s.Id == feePayment.Student.Id);
            feePayment.Student = obj;
            Create(feePayment);
        }

        public async Task<IEnumerable<FeePayment>> GetAllFeePaymentsAsync()
        {
            return await FindAll(c => c.Student)
                .OrderBy(s => s.Id)
                .ToListAsync();
        }

        public async Task<FeePayment> GetFeePaymentByIdAsync(int id)
        {
            return await FindByCondition(s => s.Id == id, p => p.Student)
                .SingleAsync();
        }

        public void UpdateFeePaymentById(int id, string remarks)
        {
            FeePayment obj = FindByCondition(f => f.Id == id).First();
            obj.Remarks = remarks;

            // Don't track the related Student entity
            dbContext.Entry(obj).State = EntityState.Modified;
        }
    }
}
