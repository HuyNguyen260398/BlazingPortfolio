namespace API.Controllers;

public class SkillController : BaseController<SkillDto>, ISkillController
{
    private readonly ISkillRepo _skillRepo;

    public SkillController(ISkillRepo skillRepo) : base(skillRepo)
    {
        _skillRepo = skillRepo;
    }
}
