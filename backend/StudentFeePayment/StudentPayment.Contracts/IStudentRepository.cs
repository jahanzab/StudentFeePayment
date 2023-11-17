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
    }
}
