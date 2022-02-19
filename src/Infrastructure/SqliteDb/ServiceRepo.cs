namespace Infrastructure.SqliteDb;

public class ServiceRepo : IServiceRepo
{
    private readonly AppDbContext _db;
    private readonly IMapper _mapper;

    public ServiceRepo(AppDbContext db, IMapper mapper)
    {
        _db = db;
        _mapper = mapper;
    }

    public async Task<bool> CreateAsync(ServiceDto entity)
    {
        if (entity == null)
            return false;

        await _db.Services.AddAsync(_mapper.Map<Service>(entity));
        return await SaveAsync();
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var entityToDelete = await _db.Services.FindAsync(id);

        if (entityToDelete == null)
            return false;

        _db.Services.Remove(entityToDelete);
        return await SaveAsync();
    }

    public async Task<IEnumerable<ServiceDto>> GetAllAsync()
    {
        return _mapper.Map<IEnumerable<ServiceDto>>(await _db.Services.ToListAsync());
    }

    public async Task<ServiceDto> GetByIdAsync(int id)
    {
        return _mapper.Map<ServiceDto>(await _db.Services.FindAsync(id));
    }

    public async Task<bool> IsExistsAsync(int id)
    {
        return await _db.Services.AnyAsync(x => x.ServiceId == id);
    }

    public async Task<bool> SaveAsync()
    {
        return await _db.SaveChangesAsync() > 0;
    }

    public async Task<bool> UpdateAsync(ServiceDto entity)
    {
        if (entity == null)
            return false;

        _db.ChangeTracker.Clear();
        _db.Entry(_mapper.Map<Service>(entity)).State = EntityState.Modified;

        return await SaveAsync();
    }
}