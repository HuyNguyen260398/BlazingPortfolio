namespace Infrastructure.MongoDb;

public class MongoDataService : IMongoDataService
{
    private readonly IMapper _mapper;
    private readonly MongoContext _mongoContext;

    public MongoDataService(IMapper mapper, MongoContext mongoContext)
    {
        _mapper = mapper;
        _mongoContext = mongoContext;
    }

    public IArchievementRepo Archievements => new ArchievementMongoRepo(_mapper, _mongoContext.Database);

    public IImageRepo Images => new ImageMongoRepo(_mapper, _mongoContext.Database);

    public IPostRepo Posts => new PostMongoRepo(_mapper, _mongoContext.Database);

    public IServiceRepo Services => new ServiceMongoRepo(_mapper, _mongoContext.Database);

    public ISkillRepo Skills => new SkillMongoRepo(_mapper, _mongoContext.Database);

    public IUserRepo Users => new UserMongoRepo(_mapper, _mongoContext.Database);
}
