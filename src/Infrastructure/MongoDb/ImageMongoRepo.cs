namespace Infrastructure.MongoDb;

public class ImageMongoRepo : IImageRepo
{
    private readonly IMapper _mapper;
    private readonly IMongoCollection<Image> _collection;

    public ImageMongoRepo(IMapper mapper, IMongoDatabase db)
    {
        _collection = db.GetCollection<Image>(MongoCollectionNames.Images);
        _mapper = mapper;
    }

    public async Task<IEnumerable<ImageDto>> GetAllAsync()
    {
        return _mapper.Map<IEnumerable<ImageDto>>(await Task.FromResult(_collection.AsQueryable()));
    }

    public async Task<ImageDto> GetByIdAsync(int id)
    {
        return _mapper.Map<ImageDto>(await _collection.FindAsync(i => i.ImageId == id));
    }

    public Task<bool> IsExistsAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> CreateAsync(ImageDto entity)
    {
        if (entity == null)
            return false;

        await _collection.InsertOneAsync(_mapper.Map<Image>(entity));
        return true;
    }

    public async Task<bool> UpdateAsync(ImageDto entity)
    {
        if (entity == null)
            return false;

        var filter = Builders<Image>.Filter.Where(x => x.ImageId == entity.ImageId);
        await _collection.ReplaceOneAsync(filter, _mapper.Map<Image>(entity));
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var filter = Builders<Image>.Filter.Where(x => x.ImageId == id);
        await _collection.DeleteOneAsync(filter);
        return true;
    }

    public Task<bool> SaveAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<ImageDto> GetImageByGuid(string guid)
    {
        return _mapper.Map<ImageDto>(await _collection.FindAsync(i => i.ImageGuid == guid));
    }

    public async Task<ImageDto> GetImageByPath(string path)
    {
        return _mapper.Map<ImageDto>(await _collection.FindAsync(i => i.RelativeImagePath == path));
    }

    public async Task<bool> SaveImageAsync(ImageDto imageDtoToSave)
    {
        if (imageDtoToSave == null)
            return false;

        await _collection.InsertOneAsync(_mapper.Map<Image>(imageDtoToSave));
        return true;
    }

    public async Task<bool> RemoveImageAsync(string guid)
    {
        var filter = Builders<Image>.Filter.Where(x => x.ImageGuid == guid);
        await _collection.DeleteOneAsync(filter);
        return true;
    }
}
