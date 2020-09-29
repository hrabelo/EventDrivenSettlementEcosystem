using AutoMapper;
using ESDE.AssetCheck.Domain.DTOs;
using ESDE.AssetCheck.Domain.Entities;

namespace ESDE.AssetCheck.Api.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Asset, AssetForDueDateDto>();
        }
    }
}
