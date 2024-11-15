using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using LearnExpress.Domain.Interfaces;
using LearnExpress.Domain;
using LearnExpress.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace LearnExpress.Infra.Data.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly LearnExpressContext _context;
        public Repository(LearnExpressContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().AsNoTracking().ToListAsync();
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> predicate)
        {
            T? t = await _context.Set<T>().AsNoTracking().FirstOrDefaultAsync(predicate);
            if(t == null) {  throw new NullReferenceException(); }
            return t;
        }

        public async Task<T> CreateAsync(T entity)
        {
            _context.Set<T>().Add(entity);
            await _context.SaveChangesAsync();
            return(entity);
        }

        public async Task<T> DeleteAsync(T entity)
        {
            _context.Remove(entity);
            await _context.SaveChangesAsync();
            return(entity);
        }

        public async Task<T> UpdateAsync(T entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
            return (entity);
        }
    }
}
