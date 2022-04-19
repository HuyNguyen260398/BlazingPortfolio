namespace Infrastructure.MongoDb;

public class ArchievementMongoRepo : IArchievementRepo
{
    private readonly IMapper _mapper;
    private readonly IMongoCollection<Archievement> _collection;

    public ArchievementMongoRepo(IMapper mapper, IMongoDatabase db)
    {
        _collection = db.GetCollection<Archievement>(MongoCollectionNames.Archievements);
        _mapper = mapper;
    }

    public async Task<IEnumerable<ArchievementDto>> GetAllAsync()
    {
        return _mapper.Map<IEnumerable<ArchievementDto>>(await Task.FromResult(_collection.AsQueryable().ToList()));
    }

    public async Task<ArchievementDto> GetByIdAsync(int id)
    {
        return _mapper.Map<ArchievementDto>(await _collection.Find(i => i.ArchievementId == id).FirstOrDefaultAsync());
    }

    public Task<bool> IsExistsAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> CreateAsync(ArchievementDto entity)
    {
        if (entity == null)
            return false;

        await _collection.InsertOneAsync(_mapper.Map<Archievement>(entity));
        return true;
    }

    public async Task<bool> UpdateAsync(ArchievementDto entity)
    {
        if (entity == null)
            return false;

        var filter = Builders<Archievement>.Filter.Where(x => x.ArchievementId == entity.ArchievementId);
        await _collection.ReplaceOneAsync(filter, _mapper.Map<Archievement>(entity));
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var filter = Builders<Archievement>.Filter.Where(x => x.ArchievementId == id);
        await _collection.DeleteOneAsync(filter);
        return true;
    }

    public Task<bool> SaveAsync()
    {
        throw new NotImplementedException();
    }
}
