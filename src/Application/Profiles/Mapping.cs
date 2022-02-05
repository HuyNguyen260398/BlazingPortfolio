namespace Application.Profiles;

public class Mapping : Profile
{
    public Mapping()
    {
        CreateMap<Archievement, ArchievementDto>().ReverseMap();
        CreateMap<Image, ImageDto>().ReverseMap();
        CreateMap<Post, PostDto>().ReverseMap();
        CreateMap<Service, ServiceDto>().ReverseMap();
        CreateMap<Skill, SkillDto>().ReverseMap();
        CreateMap<User, UserDto>().ReverseMap();
    }
}
