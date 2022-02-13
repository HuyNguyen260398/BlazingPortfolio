namespace API.Endpoints;

public class ArchievementEndpoints : IEndpoint
{
    private readonly IArchievementController _archievement;

    public ArchievementEndpoints(IArchievementController archievement)
    {
        _archievement = archievement;
    }

    public void AddRoute(IEndpointRouteBuilder app)
    {
        app.MapGet("/api/archievements", async () => await _archievement.GetAll()).WithTags("Archievement");
        app.MapGet("/api/archievements/{id}", async (int id) => await _archievement.GetById(id)).WithTags("Archievement");
        app.MapPost("/api/archievements", async (ArchievementDto ArchievementDto) => await _archievement.Create(ArchievementDto)).WithTags("Archievement");
        app.MapPut("/api/archievements", async (ArchievementDto ArchievementDto) => await _archievement.Update(ArchievementDto)).WithTags("Archievement");
        app.MapDelete("/api/archievements/{id}", async (int id) => await _archievement.Delete(id)).WithTags("Archievement");
    }
}
