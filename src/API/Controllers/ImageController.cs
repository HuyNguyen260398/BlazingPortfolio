namespace API.Controllers;

public class ImageController : BaseController<ImageDto>, IImageController
{
    private readonly IImageRepo _imageRepo;
    private readonly IWebHostEnvironment _webHostEnvironment;

    public ImageController(IImageRepo imageRepo, IWebHostEnvironment webHostEnvironment) : base(imageRepo)
    {
        _imageRepo = imageRepo;
        _webHostEnvironment = webHostEnvironment;
    }

    public async Task<IResult> GetImageByPath(string path)
    {
        try
        {
            var image = await _imageRepo.GetImageByPath(path);

            if (image == null)
                return Results.NotFound();

            return Results.Ok(image);
        }
        catch (Exception e)
        {
            return Results.Problem(e.Message);
        }
    }

    public async Task<IResult> UploadImage(ImageDto imageDtoToUpload)
    {
        try
        {
            string guid = Guid.NewGuid().ToString();
            string imageName = guid + imageDtoToUpload.NewImageExtension;
            string fullImageFileSystemPath = $"{_webHostEnvironment.ContentRootPath}\\wwwroot\\uploads\\{imageName}";

            FileStream fileStream = File.Create(fullImageFileSystemPath);
            byte[] imageAsByte = Convert.FromBase64String(imageDtoToUpload.NewImageBase64Content);
            await fileStream.WriteAsync(imageAsByte, 0, imageAsByte.Length);
            fileStream.Close();

            string relativePathWithoutTrailingSlashes = $"uploads/{imageName}";

            imageDtoToUpload.ImageGuid = guid;
            imageDtoToUpload.OldImagePath = String.Empty; // This property to be removed
            imageDtoToUpload.RelativeImagePath = relativePathWithoutTrailingSlashes;

            var isSuccess = await _imageRepo.SaveImageAsync(imageDtoToUpload);

            if (!isSuccess)
                return Results.Problem();

            return Results.Created("Create", relativePathWithoutTrailingSlashes);
        }
        catch (Exception e)
        {
            return Results.Problem(e.Message);
        }
    }

    //public async Task<IResult> RemoveImage(string guid)
    public async Task<IResult> RemoveImage(int id)
    {
        try
        {
            //var imageDtoToRemove = await _imageRepo.GetImageByGuid(guid);
            var imageDtoToRemove = await _imageRepo.GetByIdAsync(id);

            if (imageDtoToRemove == null)
                return Results.NotFound();

            if (String.IsNullOrEmpty(imageDtoToRemove.RelativeImagePath))
                return Results.NotFound();

            string imageName = imageDtoToRemove.RelativeImagePath.Split('/').Last();
            File.Delete($"{_webHostEnvironment.ContentRootPath}\\wwwroot\\uploads\\{imageName}");

            //var isSuccess = await _imageRepo.RemoveImageAsync(guid);
            var isSuccess = await _imageRepo.DeleteAsync(id);

            if (!isSuccess)
                return Results.Problem();

            return Results.NoContent();
        }
        catch (Exception e)
        {
            return Results.Problem(e.Message);
        }
    }
}
