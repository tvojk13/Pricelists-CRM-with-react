using Microsoft.EntityFrameworkCore;
using Pricelists.DataAccess.Entites;

namespace Pricelists.DataAccess
{
    public class PricelistsDbContext : DbContext
    {
        public PricelistsDbContext(DbContextOptions<PricelistsDbContext> options) : base(options) { }
        public DbSet<PricelistEntity> Pricelists { get; set; }
    }
}
