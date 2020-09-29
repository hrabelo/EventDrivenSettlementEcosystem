using AutoMapper;
using ESDE.Custody.Domain.DTOs;

namespace ESDE.Custody.Api.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Domain.Entities.Custody, CustodyForGetDto>();
        }
    }
}
