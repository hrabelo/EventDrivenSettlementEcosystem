using AutoMapper;
using ESDE.AssetCheck.Domain.DTOs;
using ESDE.AssetCheck.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ESDE.AssetCheck.Application
{
    public class AssetCheckApplication : IAssetCheckApplication
    {
        private readonly IAssetRepository _repo;
        private readonly IMapper _mapper;

        public AssetCheckApplication(IAssetRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<IEnumerable<AssetForDueDateDto>> GetAssetPastDueDate(DateTime referenceDate)
        {
            var pastDueDateAssets = await _repo.GetPastDueAssets(referenceDate);
            var assetForDueDateDtoCollection = _mapper.Map<IEnumerable<AssetForDueDateDto>>(pastDueDateAssets);
            return assetForDueDateDtoCollection;
        }
    }
}
