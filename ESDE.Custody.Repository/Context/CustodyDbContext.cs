using Microsoft.EntityFrameworkCore;

namespace ESDE.Custody.Repository.Context
{
    public class CustodyDbContext : DbContext
    {
        public CustodyDbContext(DbContextOptions options) 
            : base(options)
        {
        }

        public DbSet<Domain.Entities.Custody> Custodies { get; set; }
    }
}
