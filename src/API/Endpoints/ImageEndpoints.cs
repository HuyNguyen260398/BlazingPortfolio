namespace API.Endpoints;

public class ImageEndpoints : IEndpoint
{
    private readonly IImageController _imageController;

    public ImageEndpoints(IImageController imageController)
    {
        _imageController = imageController;
    }

    public void AddRoute(IEndpointRouteBuilder app)
    {
        app.MapGet("/api/images", [AllowAnonymous] async () => await _imageController.GetAll()).WithTags("Image");
        app.MapGet("/api/images/{path}", [AllowAnonymous] async (string path) => await _imageController.GetImageByPath(path)).WithTags("Image");
        app.MapPost("/api/images", [Authorize] async (ImageDto imageDto) => await _imageController.UploadImage(imageDto)).WithTags("Image");
        //app.MapDelete("/api/images/{guid}", async (string guid) => await _imageController.RemoveImage(guid)).WithTags("Image");
        app.MapDelete("/api/images/{id}", [Authorize] async (int id) => await _imageController.RemoveImage(id)).WithTags("Image");
    }
}
