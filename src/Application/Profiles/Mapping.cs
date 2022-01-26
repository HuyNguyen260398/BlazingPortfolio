using Application.Dtos;
using AutoMapper;
using CoreBusiness.Models;

namespace Application.Profiles;

public class Mapping : Profile
{
    public Mapping()
    {
        CreateMap<User, UserDto>().ReverseMap();
        CreateMap<Service, ServiceDto>().ReverseMap();
        CreateMap<Image, ImageDto>().ReverseMap();
        CreateMap<Archievement, ArchievementDto>().ReverseMap();
        CreateMap<Post, PostDto>().ReverseMap();
    }
}
