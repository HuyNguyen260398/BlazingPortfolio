namespace Infrastructure.MongoDb;

public class MongoRepo<T> where T : class
{
    private readonly IMongoCollection<T> _dbCollection;
    private readonly FilterDefinitionBuilder<T> _filterBuilder = Builders<T>.Filter;

    public MongoRepo(IMongoDatabase db, string collectionName)
    {
        _dbCollection = db.GetCollection<T>(collectionName);
    }

    public Task<IEnumerable<T>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<T> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> IsExistsAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> CreateAsync(PostDto entity)
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateAsync(PostDto entity)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> SaveAsync()
    {
        throw new NotImplementedException();
    }
}
