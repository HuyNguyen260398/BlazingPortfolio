namespace API.Controllers;

public class ArchievementController : BaseController<ArchievementDto>, IArchievementController
{
    private readonly IArchievementRepo _archievementRepo;

    public ArchievementController(IArchievementRepo archievementRepo) : base (archievementRepo)
    {
        _archievementRepo = archievementRepo;
    }
}
