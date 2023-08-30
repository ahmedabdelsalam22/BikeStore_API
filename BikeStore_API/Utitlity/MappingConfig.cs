using AutoMapper;
using BikeStore_API.DTOS;
using BikeStore_API.Models;

namespace BikeStore_API.Utitlity
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<Brand,BrandDTO>();
            CreateMap<BrandUpdateDTO, Brand>();
            CreateMap<BrandCreateDTO, Brand>();
        }
    }
}
