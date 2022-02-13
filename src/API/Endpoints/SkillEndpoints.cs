﻿namespace API.Endpoints;

public class SkillEndpoints : IEndpoint
{
    private readonly ISkillController _skillController;

    public SkillEndpoints(ISkillController skillController)
    {
        _skillController = skillController;
    }

    public void AddRoute(IEndpointRouteBuilder app)
    {
        app.MapGet("/api/skills", async () => await _skillController.GetAll()).WithTags("Skill");
        app.MapGet("/api/skills/{id}", async (int id) => await _skillController.GetById(id)).WithTags("Skill");
        app.MapPost("/api/skills", async (SkillDto skillDto) => await _skillController.Create(skillDto)).WithTags("Skill");
        app.MapPut("/api/skills", async (SkillDto skillDto) => await _skillController.Update(skillDto)).WithTags("Skill");
        app.MapDelete("/api/skills/{id}", async (int id) => await _skillController.Delete(id)).WithTags("Skill");
    }
}
