using AutoMapper;
using DTOs;
using Models;

namespace Mapper;

public class Mapper : Profile
{
    public Mapper()
    {
        CreateMap<City, CityModel>();
        CreateMap<Person, PersonModel>();

        CreateMap<CityModel, City>().ReverseMap();
        CreateMap<PersonModel, Person>().ReverseMap();
    }
}
