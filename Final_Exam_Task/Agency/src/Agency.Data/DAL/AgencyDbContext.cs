using Agency.Core.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agency.Data.DAL
{
    public class AgencyDbContext:DbContext
    {
        public AgencyDbContext(DbContextOptions<AgencyDbContext> options) : base(options) { }
        public DbSet<Portfolio> Portfolios { get; set; }
    }
}
