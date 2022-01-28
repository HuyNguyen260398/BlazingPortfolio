namespace API.Configs;

public static class ApiConfigs
{
    private static IUserController _userController;
    private static IServiceController _serviceController;
    private static IImageController _imageController;
    private static IArchievementController _archievementController;
    private static IPostController _postController;

    public static void InitDIContainer(
        IUserController userController,
        IServiceController serviceController,
        IImageController imageController,
        IArchievementController archievementController,
        IPostController postController)
    {
        _userController = userController;
        _serviceController = serviceController;
        _imageController = imageController;
        _archievementController = archievementController;
        _postController = postController;
    }

    public static void ConfigureApi(this WebApplication app)
    {
        // User
        app.MapGet("/api/users", async () => await _userController.GetUser());
        app.MapPut("/api/users", async (UserDto userDto) => await _userController.Update(userDto));

        // Service
        app.MapGet("/api/services", async () => await _serviceController.GetAll());
        app.MapGet("/api/services/{id}", async (int id) => await _serviceController.GetById(id));
        app.MapPost("/api/services", async (ServiceDto serviceDto) => await _serviceController.Create(serviceDto));
        app.MapPut("/api/services", async (ServiceDto serviceDto) => await _serviceController.Update(serviceDto));
        app.MapDelete("/api/services/{id}", async (int id) => await _serviceController.Delete(id));

        // Image
        app.MapGet("/api/images", async () => await _imageController.GetAll());
        app.MapPost("/api/images", async (ImageDto imageDto) => await _imageController.UploadImage(imageDto));
        app.MapDelete("/api/images/{guid}", async (string guid) => await _imageController.RemoveImage(guid));

        // Archievement
        app.MapGet("/api/archievements", async () => await _archievementController.GetAll());
        app.MapGet("/api/archievements/{id}", async (int id) => await _archievementController.GetById(id));
        app.MapPost("/api/archievements", async (ArchievementDto archievementDto) => await _archievementController.Create(archievementDto));
        app.MapPut("/api/archievements", async (ArchievementDto archievementDto) => await _archievementController.Update(archievementDto));
        app.MapDelete("/api/archievements/{id}", async (int id) => await _archievementController.Delete(id));

        // Post
        app.MapGet("/api/posts", async () => await _postController.GetAll());
        app.MapGet("/api/posts/{id}", async (int id) => await _postController.GetById(id));
        app.MapPost("/api/posts", async (PostDto postDto) => await _postController.Create(postDto));
        app.MapPut("/api/posts", async (PostDto postDto) => await _postController.Update(postDto));
        app.MapDelete("/api/posts/{id}", async (int id) => await _postController.Delete(id));
    }
}
