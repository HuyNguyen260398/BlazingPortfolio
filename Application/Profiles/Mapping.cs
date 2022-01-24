using Application.Dtos;
using AutoMapper;
using CoreBusiness.Models;

namespace Application.Profiles;

public class Mapping : Profile
{
    public Mapping()
    {
        CreateMap<User, UserDto>().ReverseMap();
    }
}
