using ESDE.AssetCheck.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ESDE.AssetCheck.Repository.Context
{
    public class AssetDbContext : DbContext
    {
        public AssetDbContext(DbContextOptions options) 
            : base(options)
        {

        }
        public DbSet<Asset> Assets { get; set; }

    }
}
