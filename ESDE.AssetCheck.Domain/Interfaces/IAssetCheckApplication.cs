using ESDE.AssetCheck.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ESDE.AssetCheck.Domain.Interfaces
{
    public interface IAssetCheckApplication 
    {
        Task<IEnumerable<AssetForDueDateDto>> GetAssetPastDueDate(DateTime referenceDate);
    }
}
