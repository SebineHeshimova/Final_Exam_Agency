using Agency.Core.Entity;
using Agency.Core.Repositories.Interfaces;
using Agency.Data.DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Agency.Data.Repositories.Implementations
{
    public class GenericRepository<T> : IGenericReposiroty<T> where T : BaseEntity, new()
    {
        private readonly AgencyDbContext _context;

        public GenericRepository(AgencyDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task CreateAsync(T entity)
        {
            await _context.AddAsync(entity);
        }

        public void Delete(T entity)
        {
            _context.Remove(entity);
        }

        public Task<List<T>> GetAllAsync(params string[]? includes)
        {
            var query = Table.AsQueryable();
            if (includes != null)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }
            return query.ToListAsync();
        }

        public IQueryable<T> GetAllWhere(Expression<Func<T, bool>>? expression = null, params string[]? includes)
        {
            var query = Table.AsQueryable();
            if (includes != null)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }
            return expression != null ?  query.Where(expression) :  query;
        }

        public async Task<T> SingleAsync(Expression<Func<T, bool>>? expression = null, params string[]? includes)
        {
            var query = Table.AsQueryable();
            if (includes != null)
            {
                foreach(var include in includes)
                {
                   query=  query.Include(include);
                }
            }
            return expression != null ? await query.Where(expression).FirstOrDefaultAsync() : await query.FirstOrDefaultAsync();
        }
    }
}
