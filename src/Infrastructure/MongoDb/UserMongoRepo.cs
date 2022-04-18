namespace Infrastructure.MongoDb;

public class UserMongoRepo : IUserRepo
{
    private readonly IMapper _mapper;
    private readonly IMongoCollection<User> _collection;

    public UserMongoRepo(IMapper mapper, IMongoDatabase db)
    {
        _collection = db.GetCollection<User>(MongoCollectionNames.Users);
        _mapper = mapper;
    }

    public async Task<IEnumerable<UserDto>> GetAllAsync()
    {
        return _mapper.Map<IEnumerable<UserDto>>(await Task.FromResult(_collection.AsQueryable()));
    }

    public async Task<UserDto> GetByIdAsync(int id)
    {
        return _mapper.Map<UserDto>(await _collection.FindAsync(i => i.UserId == id));
    }

    public Task<bool> IsExistsAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> CreateAsync(UserDto entity)
    {
        if (entity == null)
            return false;

        await _collection.InsertOneAsync(_mapper.Map<User>(entity));
        return true;
    }

    public async Task<bool> UpdateAsync(UserDto entity)
    {
        if (entity == null)
            return false;

        var filter = Builders<User>.Filter.Where(x => x.UserId == entity.UserId);
        await _collection.ReplaceOneAsync(filter, _mapper.Map<User>(entity));
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var filter = Builders<User>.Filter.Where(x => x.UserId == id);
        await _collection.DeleteOneAsync(filter);
        return true;
    }

    public Task<bool> SaveAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<UserDto> GetUserAsync()
    {
        return _mapper.Map<UserDto>(await Task.FromResult(_collection.AsQueryable().First()));
    }
}
