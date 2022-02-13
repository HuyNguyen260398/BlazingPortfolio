namespace API.Configs;

public static class ApiConfigs
{
    //private static IUserController _userController;
    //private static ISkillController _skillController;
    //private static IServiceController _serviceController;
    //private static IImageController _imageController;
    //private static IArchievementController _archievementController;
    //private static IPostController _postController;

    //public static void InitDIContainer(
    //    IUserController userController,
    //    ISkillController skillController,
    //    IServiceController serviceController,
    //    IImageController imageController,
    //    IArchievementController archievementController,
    //    IPostController postController)
    //{
    //    _userController = userController;
    //    _skillController = skillController;
    //    _serviceController = serviceController;
    //    _imageController = imageController;
    //    _archievementController = archievementController;
    //    _postController = postController;
    //}

    //public static void MapEndpoints(this WebApplication app)
    //{
    //    // User
    //    app.MapGet("/api/users", async () => await _userController.GetUser()).WithTags("User");
    //    app.MapPut("/api/users", async (UserDto userDto) => await _userController.Update(userDto)).WithTags("User");

    //    // Skill
    //    app.MapGet("/api/skills", async () => await _skillController.GetAll()).WithTags("Skill");
    //    app.MapGet("/api/skills/{id}", async (int id) => await _skillController.GetById(id)).WithTags("Skill");
    //    app.MapPost("/api/skills", async (SkillDto skillDto) => await _skillController.Create(skillDto)).WithTags("Skill");
    //    app.MapPut("/api/skills", async (SkillDto skillDto) => await _skillController.Update(skillDto)).WithTags("Skill");
    //    app.MapDelete("/api/skills/{id}", async (int id) => await _skillController.Delete(id)).WithTags("Skill");

    //    // Service
    //    app.MapGet("/api/services", async () => await _serviceController.GetAll()).WithTags("Service");
    //    app.MapGet("/api/services/{id}", async (int id) => await _serviceController.GetById(id)).WithTags("Service");
    //    app.MapPost("/api/services", async (ServiceDto serviceDto) => await _serviceController.Create(serviceDto)).WithTags("Service");
    //    app.MapPut("/api/services", async (ServiceDto serviceDto) => await _serviceController.Update(serviceDto)).WithTags("Service");
    //    app.MapDelete("/api/services/{id}", async (int id) => await _serviceController.Delete(id)).WithTags("Service");

    //    // Image
    //    app.MapGet("/api/images", async () => await _imageController.GetAll()).WithTags("Image");
    //    app.MapPost("/api/images", async (ImageDto imageDto) => await _imageController.UploadImage(imageDto)).WithTags("Image");
    //    app.MapDelete("/api/images/{guid}", async (string guid) => await _imageController.RemoveImage(guid)).WithTags("Image");

    //    // Archievement
    //    app.MapGet("/api/archievements", async () => await _archievementController.GetAll()).WithTags("Archievement");
    //    app.MapGet("/api/archievements/{id}", async (int id) => await _archievementController.GetById(id)).WithTags("Archievement");
    //    app.MapPost("/api/archievements", async (ArchievementDto archievementDto) => await _archievementController.Create(archievementDto)).WithTags("Archievement");
    //    app.MapPut("/api/archievements", async (ArchievementDto archievementDto) => await _archievementController.Update(archievementDto)).WithTags("Archievement");
    //    app.MapDelete("/api/archievements/{id}", async (int id) => await _archievementController.Delete(id)).WithTags("Archievement");

    //    // Post
    //    app.MapGet("/api/posts", async () => await _postController.GetAll()).WithTags("Post");
    //    app.MapGet("/api/posts/{id}", async (int id) => await _postController.GetById(id)).WithTags("Post");
    //    app.MapPost("/api/posts", async (PostDto postDto) => await _postController.Create(postDto)).WithTags("Post");
    //    app.MapPut("/api/posts", async (PostDto postDto) => await _postController.Update(postDto)).WithTags("Post");
    //    app.MapDelete("/api/posts/{id}", async (int id) => await _postController.Delete(id)).WithTags("Post");
    //}

    public static void MapEndpoints(this WebApplication builder)
    {
        foreach (IEndpoint service in builder.Services.CreateScope().ServiceProvider.GetServices<IEndpoint>())
        {
            service.AddRoute(builder);
        }
    }
}
