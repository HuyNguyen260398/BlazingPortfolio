namespace Infrastructure.MongoDb;

public class SkillMongoRepo : ISkillRepo
{
    private readonly IMapper _mapper;
    private readonly IMongoCollection<Skill> _collection;

    public SkillMongoRepo(IMapper mapper, IMongoDatabase db)
    {
        _collection = db.GetCollection<Skill>(MongoCollectionNames.Skills);
        _mapper = mapper;
    }

    public async Task<IEnumerable<SkillDto>> GetAllAsync()
    {
        return _mapper.Map<IEnumerable<SkillDto>>(await Task.FromResult(_collection.AsQueryable()));
    }

    public async Task<SkillDto> GetByIdAsync(int id)
    {
        return _mapper.Map<SkillDto>(await _collection.FindAsync(i => i.SkillId == id));
    }

    public Task<bool> IsExistsAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> CreateAsync(SkillDto entity)
    {
        if (entity == null)
            return false;

        await _collection.InsertOneAsync(_mapper.Map<Skill>(entity));
        return true;
    }

    public async Task<bool> UpdateAsync(SkillDto entity)
    {
        if (entity == null)
            return false;

        var filter = Builders<Skill>.Filter.Where(x => x.SkillId == entity.SkillId);
        await _collection.ReplaceOneAsync(filter, _mapper.Map<Skill>(entity));
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var filter = Builders<Skill>.Filter.Where(x => x.SkillId == id);
        await _collection.DeleteOneAsync(filter);
        return true;
    }

    public Task<bool> SaveAsync()
    {
        throw new NotImplementedException();
    }
}
