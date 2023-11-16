using AutoMapper;
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
    public class DbContextRepository : IDbContextRepository
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IMapper _mapper;

        public DbContextRepository(ApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this._mapper = mapper;
        }

        public async Task<IEnumerable<R>> GetAllAsync<S, R>()
            where S : class
            where R : class
        {
            var result = await this.dbContext.Set<S>().AsNoTracking().ToListAsync();

            return _mapper.Map<List<S>, List<R>>(result);
        }

        public async Task<R> GetFirstWhere<S, R>(Expression<Func<S, bool>> exp)
            where S : class
            where R : class
        {
            return _mapper.Map<R>(await dbContext.Set<S>().Where(exp).FirstOrDefaultAsync());
        }

        public async Task<S?> GetFirstWhere<S>(Expression<Func<S, bool>> exp)
        where S : class
        {
            return await dbContext.Set<S>().Where(exp).FirstOrDefaultAsync();
        }

        public async Task<R> SaveChangesAsync<S, R>(S obj)
            where S : class
            where R : class
        {
            //dbContext.Entry(obj).State = obj == 0 ? EntityState.Added : EntityState.Modified;
            //dbContext.Entry(obj).State = EntityState.Added;
            await dbContext.Set<S>().AddAsync(obj);
            await dbContext.SaveChangesAsync();

            return _mapper.Map<R>(obj);
        }

        public async Task SaveChangesAsync<S>(S obj)
            where S : class
        {
            await dbContext.Set<S>().AddAsync(obj);
            await dbContext.SaveChangesAsync();
        }

        public async Task<R?> UpdatetFirstWhere<S, R>(Expression<Func<S, bool>> exp, S updatedData)
            where S : class
            where R : class
        {
            var obj = await dbContext.Set<S>().Where(exp).FirstOrDefaultAsync();

            if (obj == null)
                return null;

            dbContext.Entry(obj).CurrentValues.SetValues(updatedData);
            await dbContext.SaveChangesAsync();

            return _mapper.Map<R>(obj);
        }

        public async Task<R?> DeleteFirstWhere<S, R>(Expression<Func<S, bool>> exp)
            where S : class
            where R : class
        {
            var obj = await dbContext.Set<S>().Where(exp).FirstOrDefaultAsync();

            if (obj == null)
                return null;

            dbContext.Set<S>().Remove(obj);
            await dbContext.SaveChangesAsync();

            return _mapper.Map<R>(obj);
        }
    }
}
