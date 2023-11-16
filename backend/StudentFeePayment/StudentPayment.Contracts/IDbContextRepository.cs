using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace StudentPayment.Contracts
{
    public interface IDbContextRepository
    {
        //Task<R> SaveChangesAsync<S, T, R>(S req)
        //    where T : class
        //    where S : class
        //    where R : class;

        //Task<S> SaveChangesAsync<S>(S obj) 
        //    where S : class;

        Task<R> SaveChangesAsync<S, R>(S obj)
            where S : class
            where R : class;

        Task SaveChangesAsync<S>(S obj)
        where S : class;

        Task<IEnumerable<R>> GetAllAsync<S, R>()
            where S : class
            where R : class;

        Task<R> GetFirstWhere<S, R>(Expression<Func<S, bool>> exp)
            where S : class
            where R : class;

        Task<S?> GetFirstWhere<S>(Expression<Func<S, bool>> exp)
            where S : class;

        Task<R?> UpdatetFirstWhere<S, R>(Expression<Func<S, bool>> exp, S updatedData)
            where S : class
            where R : class;

        Task<R?> DeleteFirstWhere<S, R>(Expression<Func<S, bool>> exp)
            where S : class
            where R : class;
    }
}
