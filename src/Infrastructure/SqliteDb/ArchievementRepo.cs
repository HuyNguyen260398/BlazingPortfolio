namespace Infrastructure.SqliteDb;

public class ArchievementRepo : IArchievementRepo
{
    private readonly AppDbContext _db;
    private readonly IMapper _mapper;

    public ArchievementRepo(AppDbContext db, IMapper mapper)
    {
        _db = db;
        _mapper = mapper;
    }

    public async Task<bool> CreateAsync(ArchievementDto entity)
    {
        if (entity == null)
            return false;

        await _db.Archievements.AddAsync(_mapper.Map<Archievement>(entity));
        return await SaveAsync();
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var entityToDelete = await _db.Archievements.FindAsync(id);

        if (entityToDelete == null)
            return false;

        _db.Archievements.Remove(entityToDelete);
        return await SaveAsync();
    }

    public async Task<IEnumerable<ArchievementDto>> GetAllAsync()
    {
        var archievements = _mapper.Map<IEnumerable<ArchievementDto>>(await _db.Archievements.ToListAsync());
        return archievements;
    }

    public async Task<ArchievementDto> GetByIdAsync(int id)
    {
        return _mapper.Map<ArchievementDto>(await _db.Archievements.FindAsync(id));
    }

    public async Task<bool> IsExistsAsync(int id)
    {
        return await _db.Archievements.AnyAsync(x => x.ArchievementId == id);
    }

    public async Task<bool> SaveAsync()
    {
        return await _db.SaveChangesAsync() > 0;
    }

    public async Task<bool> UpdateAsync(ArchievementDto entity)
    {
        if (entity == null)
            return false;

        _db.ChangeTracker.Clear();
        _db.Entry(_mapper.Map<Archievement>(entity)).State = EntityState.Modified;

        return await SaveAsync();
    }
}

