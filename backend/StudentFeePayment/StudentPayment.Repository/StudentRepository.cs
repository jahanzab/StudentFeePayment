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
        private readonly ApplicationDbContext dbContext;

        public StudentRepository(ApplicationDbContext dbContext)
            :base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public void CreateStudent(Student student)
        {
            Create(student);
        }

        public async Task<IEnumerable<Student>> GetAllStudentsAsync()
        {
            return await FindAll()
                .OrderBy(s => s.Id)
                .ToListAsync();
        }

        public async Task<Student> GetStudentByIdAsync(int id)
        {
            return await FindByCondition(s => s.Id == id)
                .SingleAsync();
        }

        public Student UpdateStudentById(Student student)
        {
            var existingStudent = dbContext.Students
               .First(b => b.Id == student.Id);

            dbContext.Entry(existingStudent).CurrentValues.SetValues(student);

            Update(existingStudent);
            return existingStudent;
        }
    }
}
