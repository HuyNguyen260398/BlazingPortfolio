using Application.Dtos;

namespace Application.Interfaces;

public interface IImageRepo : IBaseRepo<ImageDto>
{
    Task<ImageDto> GetImageByGuid(string guid);
    Task<bool> SaveImageAsync(ImageDto imageDtoToSave);
    Task<bool> RemoveImageAsync(string guid);
}
