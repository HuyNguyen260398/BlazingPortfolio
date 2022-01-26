namespace Infrastructure.InMemDb;

public class ArchievementInMemRepo : IArchievementRepo
{
    private static List<Archievement> _archievements = new()
    {
        new Archievement { ArchievementId = 1, Name = "Happy Clients", Count = 111 },
        new Archievement { ArchievementId = 2, Name = "Projects Finished", Count = 333 },
        new Archievement { ArchievementId = 4, Name = "Certificates Archieved", Count = 555 },
        new Archievement { ArchievementId = 3, Name = "Awards Won", Count = 777 },
    };

    private readonly IMapper _mapper;

    public ArchievementInMemRepo(IMapper mapper)
    {
        _mapper = mapper;
    }

    public async Task<IEnumerable<ArchievementDto>> GetAllAsync()
    {
        return await Task.FromResult(_mapper.Map<List<ArchievementDto>>(_archievements));
    }

    public async Task<ArchievementDto> GetByIdAsync(int id)
    {
        return await Task.FromResult(_mapper.Map<ArchievementDto>(_archievements.Find(a => a.ArchievementId == id)));
    }

    public async Task<bool> IsExistsAsync(int id)
    {
        return await Task.FromResult(_archievements.Any(a => a.ArchievementId == id));
    }

    public async Task<bool> CreateAsync(ArchievementDto archievementDtoToCreate)
    {
        var archievementToCreate = _mapper.Map<Archievement>(archievementDtoToCreate);

        if (_archievements.Any(a => a.Name.Equals(archievementToCreate.Name, StringComparison.OrdinalIgnoreCase)))
            return await Task.FromResult(false);

        if (_archievements != null && _archievements.Count > 0)
            archievementToCreate.ArchievementId = _archievements.Max(a => a.ArchievementId) + 1;
        else
            archievementToCreate.ArchievementId = 1;

        _archievements.Add(archievementToCreate);
        return await SaveAsync();
    }

    public async Task<bool> UpdateAsync(ArchievementDto archievementDtoToUpdate)
    {
        var archievementToUpdate = _mapper.Map<Archievement>(archievementDtoToUpdate);

        var index = _archievements.FindIndex(a => a.ArchievementId == archievementToUpdate.ArchievementId);

        if (index < 0)
            return await Task.FromResult(false);

        _archievements[index] = archievementToUpdate;
        return await SaveAsync();
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var index = _archievements.FindIndex(a => a.ArchievementId == id);

        if (index < 0)
            return await Task.FromResult(false);

        _archievements.RemoveAt(index);
        return await SaveAsync();
    }

    public async Task<bool> SaveAsync()
    {
        return await Task.FromResult(true);
    }
}
