using ESDE.AssetCheck.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ESDE.AssetCheck.Domain.Interfaces
{
    public interface IAssetRepository
    {
        Task<IEnumerable<Asset>> GetPastDueAssets(DateTime referenceDate);
    }
}
