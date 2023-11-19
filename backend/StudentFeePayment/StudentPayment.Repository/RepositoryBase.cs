using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentFeePayment.Entities;
using StudentPayment.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace StudentPayment.Repository
{
    /// <summary>
    /// Create Base repository class for db access & data manipulation
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected ApplicationDbContext applicationDbContext { get; set; }
        public RepositoryBase(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public IQueryable<T> FindAll() => applicationDbContext.Set<T>().AsNoTracking();
        public IQueryable<T> FindAll(params Expression<Func<T, object>>[] includes)
        {
            var query = FindAll();
            if (includes != null)
            {
                query = includes.Aggregate(query,
                          (current, include) => current.Include(include));
            }
            return query;
        }
        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression) =>
            applicationDbContext.Set<T>().Where(expression).AsNoTracking();
        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, params Expression<Func<T, object>>[] includes)
        {
            var query = FindByCondition(expression);
            if (includes != null)
            {
                query = includes.Aggregate(query,
                          (current, include) => current.Include(include));
            }
            return query;
        }
        public void Create(T entity) => applicationDbContext.Set<T>().Add(entity);
        public void Update(T entity) => applicationDbContext.Set<T>().Update(entity);
        public void Delete(T entity) => applicationDbContext.Set<T>().Remove(entity);
    }
}
