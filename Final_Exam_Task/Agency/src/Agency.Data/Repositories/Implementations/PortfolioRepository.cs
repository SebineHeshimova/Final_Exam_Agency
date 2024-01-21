using Agency.Core.Entity;
using Agency.Core.Repositories.Interfaces;
using Agency.Data.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agency.Data.Repositories.Implementations
{
    public class PortfolioRepository : GenericRepository<Portfolio>, IPortfolioRepository
    {
        public PortfolioRepository(AgencyDbContext context) : base(context)
        {
        }
    }
}
