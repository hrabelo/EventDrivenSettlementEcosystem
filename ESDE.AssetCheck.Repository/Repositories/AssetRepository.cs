using ESDE.AssetCheck.Domain.Entities;
using ESDE.AssetCheck.Domain.Interfaces;
using ESDE.AssetCheck.Repository.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ESDE.AssetCheck.Repository.Repositories
{
    public class AssetRepository : IAssetRepository
    {
        private readonly AssetDbContext _context;

        public AssetRepository(AssetDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Asset>> GetPastDueAssets(DateTime referenceDate)
        {
            var pastDueAssets = await _context.Assets.Where(o => o.DueDate.Date == referenceDate.Date).ToListAsync();
            return pastDueAssets;
        }
    }
}
