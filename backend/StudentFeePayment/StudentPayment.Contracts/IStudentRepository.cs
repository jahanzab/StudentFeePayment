using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentFeePayment.Entities.Models.Domain;

namespace StudentPayment.Contracts
{
    public interface IStudentRepository
    {
        Task<T> CreateAsync<T>(Student obj)
           where T : class;

        Task<IEnumerable<T>> GetAllAsync<T>()
            where T : class;

        Task<T?> GetByIdAsync<T>(int id) where T : class;

        Task<Student?> GetByIdAsync(int id);

        Task<T?> UpdateAsync<T>(int id, Student student) where T : class;

        Task<T?> DeleteAsync<T>(int id) where T : class;
    }
}
