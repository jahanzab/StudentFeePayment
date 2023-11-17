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
    public class StudentRepository : RepositoryBase<Student> ,IStudentRepository
    {
        public StudentRepository(ApplicationDbContext dbContext)
            :base(dbContext)
        {
        }

        public async Task<IEnumerable<Student>> GetAllStudentsAsync()
        {
            return await FindAll()
                .OrderBy(s => s.Id)
                .ToListAsync();
        }
    }
}
