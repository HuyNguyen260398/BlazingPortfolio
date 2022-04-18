namespace Infrastructure.MongoDb;

public class ServiceMongoRepo : IServiceRepo
{
    private readonly IMapper _mapper;
    private readonly IMongoCollection<Service> _collection;

    public ServiceMongoRepo(IMapper mapper, IMongoDatabase db)
    {
        _collection = db.GetCollection<Service>(MongoCollectionNames.Services);
        _mapper = mapper;
    }

    public async Task<IEnumerable<ServiceDto>> GetAllAsync()
    {
        return _mapper.Map<IEnumerable<ServiceDto>>(await Task.FromResult(_collection.AsQueryable()));
    }

    public async Task<ServiceDto> GetByIdAsync(int id)
    {
        return _mapper.Map<ServiceDto>(await _collection.FindAsync(i => i.ServiceId == id));
    }

    public Task<bool> IsExistsAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> CreateAsync(ServiceDto entity)
    {
        if (entity == null)
            return false;

        await _collection.InsertOneAsync(_mapper.Map<Service>(entity));
        return true;
    }

    public async Task<bool> UpdateAsync(ServiceDto entity)
    {
        if (entity == null)
            return false;

        var filter = Builders<Service>.Filter.Where(x => x.ServiceId == entity.ServiceId);
        await _collection.ReplaceOneAsync(filter, _mapper.Map<Service>(entity));
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var filter = Builders<Service>.Filter.Where(x => x.ServiceId == id);
        await _collection.DeleteOneAsync(filter);
        return true;
    }

    public Task<bool> SaveAsync()
    {
        throw new NotImplementedException();
    }
}
