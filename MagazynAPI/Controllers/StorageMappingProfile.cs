using AutoMapper;
using MagazynAPI.Entities;
using MagazynAPI.Models;

namespace MagazynAPI.Controllers
{
    public class StorageMappingProfile : Profile
    {
        public StorageMappingProfile()
        {
            CreateMap<Storage, StorageDto>()
                .ForMember(m => m.City, c => c.MapFrom(s => s.Address.City))
                .ForMember(m => m.Street, c => c.MapFrom(s => s.Address.Street))
                .ForMember(m => m.PostalCode, c => c.MapFrom(s => s.Address.PostalCode));

            CreateMap<Item, ItemDto>();
        }
    }
}
