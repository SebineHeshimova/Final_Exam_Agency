using Agency.Core.Repositories.Interfaces;
using Agency.Data.Repositories.Implementations;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agency.Data
{
    public static class ServiceRegistration
    {
        public static void AddRepository(this IServiceCollection services)
        {
            services.AddScoped<IPortfolioRepository, PortfolioRepository>();
        }
    }
}
