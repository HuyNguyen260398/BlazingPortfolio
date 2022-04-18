namespace Infrastructure.MongoDb;

public class PostMongoRepo : IPostRepo
{
    private readonly IMapper _mapper;
    private readonly IMongoCollection<Post> _collection;

    public PostMongoRepo(IMapper mapper, IMongoDatabase db)
    {
        _collection = db.GetCollection<Post>(MongoCollectionNames.Posts);
        _mapper = mapper;
    }

    public async Task<IEnumerable<PostDto>> GetAllAsync()
    {
        return _mapper.Map<IEnumerable<PostDto>>(await Task.FromResult(_collection.AsQueryable()));
    }

    public async Task<PostDto> GetByIdAsync(int id)
    {
        return _mapper.Map<PostDto>(await _collection.FindAsync(i => i.PostId == id));
    }

    public Task<bool> IsExistsAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> CreateAsync(PostDto entity)
    {
        if (entity == null)
            return false;

        await _collection.InsertOneAsync(_mapper.Map<Post>(entity));
        return true;
    }

    public async Task<bool> UpdateAsync(PostDto entity)
    {
        if (entity == null)
            return false;

        var filter = Builders<Post>.Filter.Where(x => x.PostId == entity.PostId);
        await _collection.ReplaceOneAsync(filter, _mapper.Map<Post>(entity));
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var filter = Builders<Post>.Filter.Where(x => x.PostId == id);
        await _collection.DeleteOneAsync(filter);
        return true;
    }

    public Task<bool> SaveAsync()
    {
        throw new NotImplementedException();
    }
}
