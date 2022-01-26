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

    public async Task<IResult> UploadImage(ImageDto imageDtoToUpload)
    {
        try
        {
            if (imageDtoToUpload.OldImagePath != string.Empty)
            {
                string oldImageName = imageDtoToUpload.OldImagePath.Split('/').Last();
                File.Delete($"{_webHostEnvironment.ContentRootPath}\\wwwroot\\uploads\\{oldImageName}");
            }

            string guid = Guid.NewGuid().ToString();
            string imageName = guid + imageDtoToUpload.NewImageExtension;
            string fullImageFileSystemPath = $"{_webHostEnvironment.ContentRootPath}\\wwwroot\\uploads\\{imageName}";

            FileStream fileStream = File.Create(fullImageFileSystemPath);
            byte[] imageAsByte = Convert.FromBase64String(imageDtoToUpload.NewImageBase64Content);
            await fileStream.WriteAsync(imageAsByte, 0, imageAsByte.Length);
            fileStream.Close();

            string relativePathWithoutTrailingSlashes = $"uploads/{imageName}";

            imageDtoToUpload.ImageGuid = guid;
            imageDtoToUpload.RelativeImagePath = relativePathWithoutTrailingSlashes;

            var isSuccess = await _imageRepo.SaveImageAsync(imageDtoToUpload);

            if (!isSuccess)
                return Results.Problem();

            return Results.Created("Create", imageDtoToUpload);
        }
        catch (Exception e)
        {
            return Results.Problem(e.Message);
        }
    }

    public async Task<IResult> RemoveImage(string guid)
    {
        try
        {
            var imageDtoToRemove = await _imageRepo.GetImageByGuid(guid);

            if (imageDtoToRemove == null)
                return Results.NotFound();

            if (String.IsNullOrEmpty(imageDtoToRemove.RelativeImagePath))
                return Results.NotFound();

            string imageName = imageDtoToRemove.RelativeImagePath.Split('/').Last();
            File.Delete($"{_webHostEnvironment.ContentRootPath}\\wwwroot\\uploads\\{imageName}");

            var isSuccess = await _imageRepo.RemoveImageAsync(guid);

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
