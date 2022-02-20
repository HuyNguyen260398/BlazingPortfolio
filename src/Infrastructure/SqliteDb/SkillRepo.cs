namespace Infrastructure.SqliteDb;

public class SkillRepo : ISkillRepo
{
    private readonly AppDbContext _db;
    private readonly IMapper _mapper;

    public SkillRepo(AppDbContext db, IMapper mapper)
    {
        _db = db;
        _mapper = mapper;
    }

    public async Task<bool> CreateAsync(SkillDto entity)
    {
        if (entity == null)
            return false;

        await _db.Skills.AddAsync(_mapper.Map<Skill>(entity));
        return await SaveAsync();
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var entityToDelete = await _db.Skills.FindAsync(id);

        if (entityToDelete == null)
            return false;

        _db.Skills.Remove(entityToDelete);
        return await SaveAsync();
    }

    public async Task<IEnumerable<SkillDto>> GetAllAsync()
    {
        return _mapper.Map<IEnumerable<SkillDto>>(await _db.Skills.ToListAsync());
    }

    public async Task<SkillDto> GetByIdAsync(int id)
    {
        return _mapper.Map<SkillDto>(await _db.Skills.FindAsync(id));
    }

    public async Task<bool> IsExistsAsync(int id)
    {
        return await _db.Skills.AnyAsync(x => x.SkillId == id);
    }

    public async Task<bool> SaveAsync()
    {
        return await _db.SaveChangesAsync() > 0;
    }

    public async Task<bool> UpdateAsync(SkillDto entity)
    {
        if (entity == null)
            return false;

        _db.ChangeTracker.Clear();
        _db.Entry(_mapper.Map<Skill>(entity)).State = EntityState.Modified;

        return await SaveAsync();
    }
}