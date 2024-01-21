using Agency.Business.CustomExceptions.AgencyExceptions;
using Agency.Business.Extensions;
using Agency.Business.Services.Interfaces;
using Agency.Core.Entity;
using Agency.Core.Repositories.Interfaces;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Agency.Business.Services.Implementations
{
    public class PortfolioService : IPortfolioService
    {
        private readonly IWebHostEnvironment _env;
        private readonly IPortfolioRepository _repository;
        public PortfolioService(IWebHostEnvironment env, IPortfolioRepository repository)
        {
            _env = env;
            _repository = repository;
        }

        public async Task CreateAsync(Portfolio portfolio)
        {
            
            if (portfolio == null) throw new EntityNullException("Entity can not null!");
            if(portfolio.ImageFile != null)
            {
                if (portfolio.ImageFile.ContentType != "image/png" && portfolio.ImageFile.ContentType != "image/jpeg")
                {
                    throw new PortfolioImageFileContentTypeException("ImageFile", "Must be content type png ot jpeg!");
                }
                if(portfolio.ImageFile.Length > 2097152)
                {
                    throw new PortfolioImageFileLengthException("ImageFile", "Invalid image length");
                }
                portfolio.ImageUrl = Helper.SaveFile(_env.WebRootPath, "uploads/portfolios", portfolio.ImageFile);
            }
            portfolio.CreatedDate = DateTime.UtcNow.AddHours(4);
            portfolio.UpdatedDate = DateTime.UtcNow.AddHours(4);
            portfolio.IsDeleted = false;
            await _repository.CreateAsync(portfolio);
            await _repository.CommitAsync();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Portfolio>> GetAllAsync(Expression<Func<Portfolio, bool>>? expression = null, params string[]? includes)
        {
            throw new NotImplementedException();
        }

        public Task<Portfolio> GetByIdAsync(Expression<Func<Portfolio, bool>>? expression = null, params string[]? includes)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Portfolio portfolio)
        {
            throw new NotImplementedException();
        }
    }
}
