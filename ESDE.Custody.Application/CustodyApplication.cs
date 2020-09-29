using AutoMapper;
using ESDE.Custody.Domain.DTOs;
using ESDE.Custody.Domain.Interfaces;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ESDE.Custody.Application
{
    public class CustodyApplication : ICustodyApplication
    {
        private readonly ICustodyRepository _repo;
        private readonly IMapper _mapper;

        public CustodyApplication(ICustodyRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CustodyForGetDto>> GetAll()
        {
            var custodies = await _repo.GetAll();
            var mappedDtoCustodies = _mapper.Map<IEnumerable<CustodyForGetDto>>(custodies);

            return mappedDtoCustodies;
        }

        public async void Process(string message)
        {
            var assetData = JsonConvert.DeserializeObject<IEnumerable<AssetForDueDateDto>>(message);
            var custodies = await _repo.GetAll();
            foreach (var asset in assetData)
            {
                var custodiesToRemove = custodies.Where(o => o.AssetId == asset.Id);

                foreach(var custody in custodiesToRemove)
                {
                    _repo.Remove(custody);
                }

            }

            _repo.SaveAll();
        }
    }
}
