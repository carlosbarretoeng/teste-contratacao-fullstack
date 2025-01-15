using application.DTOs;
using AutoMapper;
using domain.Entities;

namespace application.Mappings;

public class DomainToDtoMappingProfile: Profile
{
    public DomainToDtoMappingProfile()
    {
        CreateMap<Person, PersonDto>().ReverseMap();
        CreateMap<User, UserDto>().ReverseMap();
        CreateMap<Vehicle, VehicleDto>().ReverseMap();
    }
}