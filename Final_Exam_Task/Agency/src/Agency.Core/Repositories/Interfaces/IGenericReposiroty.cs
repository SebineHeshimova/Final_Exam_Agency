using Agency.Core.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Agency.Core.Repositories.Interfaces
{
    public interface IGenericReposiroty<T> where T : BaseEntity, new()
    {
        public DbSet<T> Table { get; }
        Task CreateAsync(T entity);
        Task CommitAsync();
        void Delete(T entity);
        Task<List<T>> GetAllAsync(params string[]? includes);
        IQueryable<T> GetAllWhere(Expression<Func<T, bool>>? expression=null, params string[]? includes);
        Task<T> SingleAsync(Expression<Func<T, bool>>? expression = null, params string[]? includes);
    }
}
