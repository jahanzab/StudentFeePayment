using StudentFeePayment.Entities;
using StudentPayment.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentPayment.Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private readonly ApplicationDbContext _dbContext;
        private IStudentRepository _studentRepository;
        private IFeePaymentRepository _feePaymentRepository;

        public RepositoryWrapper(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IStudentRepository Student
        {
            get
            {
                _studentRepository ??= new StudentRepository(_dbContext);
                return _studentRepository;
            }
        }

        public IFeePaymentRepository FeePayment
        {
            get
            {
                _feePaymentRepository ??= new FeePaymentRepository(_dbContext);
                return _feePaymentRepository;
            }
        }

        public async Task SaveAsync()
        {
           await _dbContext.SaveChangesAsync();
        }
    }
}
