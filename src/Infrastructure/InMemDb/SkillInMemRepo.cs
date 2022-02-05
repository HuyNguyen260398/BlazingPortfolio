namespace Infrastructure.InMemDb;

public class SkillInMemRepo : ISkillRepo
{
    private static List<Skill> _skills = new()
    {
        new Skill { SkillId = 1, Name = "C#", YearsOfExperience = 3, ScorePercentage = 0.9m },
        new Skill { SkillId = 2, Name = "SQL", YearsOfExperience = 1, ScorePercentage = 0.5m },
        new Skill { SkillId = 3, Name = "DotNet", YearsOfExperience = 2, ScorePercentage = 0.7m },
        new Skill { SkillId = 4, Name = "Blazor", YearsOfExperience = 2, ScorePercentage = 0.7m },
    };

    private readonly IMapper _mapper;

    public SkillInMemRepo(IMapper mapper)
    {
        _mapper = mapper;
    }

    public async Task<IEnumerable<SkillDto>> GetAllAsync()
    {
        return await Task.FromResult(_mapper.Map<List<SkillDto>>(_skills));
    }

    public async Task<SkillDto> GetByIdAsync(int id)
    {
        return await Task.FromResult(_mapper.Map<SkillDto>(_skills.Find(a => a.SkillId == id)));
    }

    public async Task<bool> IsExistsAsync(int id)
    {
        return await Task.FromResult(_skills.Any(a => a.SkillId == id));
    }

    public async Task<bool> CreateAsync(SkillDto skillDtoToCreate)
    {
        var skillToCreate = _mapper.Map<Skill>(skillDtoToCreate);

        if (_skills.Any(a => a.Name.Equals(skillToCreate.Name, StringComparison.OrdinalIgnoreCase)))
            return await Task.FromResult(false);

        if (_skills != null && _skills.Count > 0)
            skillToCreate.SkillId = _skills.Max(a => a.SkillId) + 1;
        else
            skillToCreate.SkillId = 1;

        _skills.Add(skillToCreate);
        return await SaveAsync();
    }

    public async Task<bool> UpdateAsync(SkillDto skillDtoToUpdate)
    {
        var skillToUpdate = _mapper.Map<Skill>(skillDtoToUpdate);

        var index = _skills.FindIndex(a => a.SkillId == skillToUpdate.SkillId);

        if (index < 0)
            return await Task.FromResult(false);

        _skills[index] = skillToUpdate;
        return await SaveAsync();
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var index = _skills.FindIndex(a => a.SkillId == id);

        if (index < 0)
            return await Task.FromResult(false);

        _skills.RemoveAt(index);
        return await SaveAsync();
    }

    public async Task<bool> SaveAsync()
    {
        return await Task.FromResult(true);
    }
}
