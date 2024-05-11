using AutoMapper;
using DTOs;
using Models;

namespace Mapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<City, CityModel>();
        CreateMap<Person, PersonModel>();

        CreateMap<CityModel, City>().ReverseMap();
        CreateMap<PersonModel, Person>().ReverseMap();
    }
}
