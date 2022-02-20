namespace WASM.Interfaces;

public interface IImageRepo : IBaseRepo<ImageDto>
{
    Task<string> SaveImageAsync(string url, ImageDto image);
    Task<bool> RemoveImageAsync(string url, string guid);
}
