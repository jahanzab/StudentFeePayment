using StudentFeePayment.Entities.Models.Domain;
using StudentFeePayment.Entities.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentPayment.Contracts
{
    public interface IStudentRepository
    {
       Task<IEnumerable<Student>> GetAllStudentsAsync();
       Task<Student> GetStudentByIdAsync(int id);
       Student UpdateStudentById(Student student);
       void CreateStudent(Student student);
       void DeleteStudent(int id);
       bool IsupdateOrCreate(string studentNumber);
    }
}
