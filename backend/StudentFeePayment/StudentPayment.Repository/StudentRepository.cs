using StudentFeePayment.Entities.Models.Domain;
using StudentPayment.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentPayment.Repository
{
    public class StudentRepository: IStudentRepository
    {
        private readonly IDbContextRepository _dbContextRepository;

        public StudentRepository(IDbContextRepository dbContextRepository)
        {
            this._dbContextRepository = dbContextRepository;
        }

        public async Task<T> CreateAsync<T>(Student obj)
            where T : class
        {
            return await _dbContextRepository.SaveChangesAsync<Student, T>(obj);
        }

        public async Task<IEnumerable<T>> GetAllAsync<T>() where T : class
        {
            return await _dbContextRepository.GetAllAsync<Student, T>();
        }

        public async Task<T?> GetByIdAsync<T>(int id) where T : class
        {
            return await _dbContextRepository.GetFirstWhere<Student, T>(
                obj => obj.Id == id);
        }

        public async Task<Student?> GetByIdAsync(int id)
        {
            return await _dbContextRepository.GetFirstWhere<Student>(
                obj => obj.Id == id);
        }

        public async Task<T?> UpdateAsync<T>(int id, Student category) where T : class
        {
            return await _dbContextRepository.UpdatetFirstWhere<Student, T>(
                obj => obj.Id == id, category);
        }

        public async Task<T?> DeleteAsync<T>(int id) where T : class
        {
            return await _dbContextRepository.DeleteFirstWhere<Student, T>(
                obj => obj.Id == id);
        }
    }
}
