namespace Application.Interfaces;

public interface IMongoDataService
{
    public IArchievementRepo Archievements { get; }
    public IImageRepo Images { get; }
    public IPostRepo Posts { get; }
    public IServiceRepo Services { get; }
    public ISkillRepo Skills { get; }
    public IUserRepo Users { get; }
}
