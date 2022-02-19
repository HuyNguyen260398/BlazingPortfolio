namespace Infrastructure.SqliteDb;

public class UserRepo : IUserRepo
{
    private readonly AppDbContext _db;
    private readonly IMapper _mapper;

    public UserRepo(AppDbContext db, IMapper mapper)
    {
        _db = db;
        _mapper = mapper;
    }

    public Task<bool> CreateAsync(UserDto entity)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<UserDto>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<UserDto> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<UserDto> GetUserAsync()
    {
        return _mapper.Map<UserDto>((await _db.Users.AsNoTracking().ToListAsync()).First());
    }

    public Task<bool> IsExistsAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> SaveAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<bool> UpdateAsync(UserDto entity)
    {
        if (entity == null)
            return false;

        _db.ChangeTracker.Clear();
        _db.Entry(_mapper.Map<User>(entity)).State = EntityState.Modified;

        return await _db.SaveChangesAsync() > 0;
    }
}
