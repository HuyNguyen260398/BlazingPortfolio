namespace Infrastructure.SqliteDb;

public class PostRepo : IPostRepo
{
    private readonly AppDbContext _db;
    private readonly IMapper _mapper;

    public PostRepo(AppDbContext db, IMapper mapper)
    {
        _db = db;
        _mapper = mapper;
    }

    public async Task<bool> CreateAsync(PostDto entity)
    {
        if (entity == null)
            return false;

        await _db.AddAsync(_mapper.Map<Post>(entity));
        return await SaveAsync();
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var entityToDelete = await _db.Posts.FindAsync(id);
        if (entityToDelete == null)
            return false;

        _db.Posts.Remove(entityToDelete);
        return await SaveAsync();
    }

    public async Task<IEnumerable<PostDto>> GetAllAsync()
    {
        return _mapper.Map<IEnumerable<PostDto>>(await _db.Posts.ToListAsync());
    }

    public async Task<PostDto> GetByIdAsync(int id)
    {
        return _mapper.Map<PostDto>(await _db.Posts.FindAsync(id));
    }

    public async Task<bool> IsExistsAsync(int id)
    {
        return await _db.Posts.AnyAsync(x => x.PostId == id);
    }

    public async Task<bool> SaveAsync()
    {
        return await _db.SaveChangesAsync() > 0;
    }

    public async Task<bool> UpdateAsync(PostDto entity)
    {
        if (entity == null)
            return false;

        _db.ChangeTracker.Clear();
        _db.Entry(_mapper.Map<Post>(entity)).State = EntityState.Modified;

        return await SaveAsync();
    }
}
