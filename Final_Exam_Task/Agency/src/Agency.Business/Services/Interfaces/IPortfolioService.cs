using Agency.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Agency.Business.Services.Interfaces
{
    public interface IPortfolioService
    {
        Task CreateAsync(Portfolio portfolio);
        Task UpdateAsync(Portfolio portfolio);
        Task DeleteAsync(int id);
        Task<Portfolio> GetByIdAsync(Expression<Func<Portfolio, bool>>? expression = null, params string[]? includes);
        Task<List<Portfolio>> GetAllAsync(Expression<Func<Portfolio, bool>>? expression = null, params string[]? includes);
    }
}
