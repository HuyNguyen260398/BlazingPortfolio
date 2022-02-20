namespace API.Interfaces;

public interface IImageController : IBaseController<ImageDto>
{
    Task<IResult> UploadImage(ImageDto imageDtoToUpload);
    //Task<IResult> RemoveImage(string guid);
    Task<IResult> RemoveImage(int id);
}
