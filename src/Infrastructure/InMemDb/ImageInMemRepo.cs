namespace Infrastructure.InMemDb;

public class ImageInMemRepo : IImageRepo
{
    private readonly List<Image> _images = new()
    {
        new Image 
        { 
            ImageGuid = Guid.NewGuid().ToString(), 
            NewImageExtension = ".png", 
            NewImageBase64Content = String.Empty, 
            OldImagePath = String.Empty,
            RelativeImagePath = String.Empty
        },
        new Image 
        { 
            ImageGuid = Guid.NewGuid().ToString(), 
            NewImageExtension = ".png", 
            NewImageBase64Content = String.Empty, 
            OldImagePath = String.Empty,
            RelativeImagePath= String.Empty
        },
        new Image 
        { 
            ImageGuid = Guid.NewGuid().ToString(), 
            NewImageExtension = ".png", 
            NewImageBase64Content = String.Empty, 
            OldImagePath = String.Empty,
            RelativeImagePath = String.Empty
        }
    };

    private readonly IMapper _mapper;

    public ImageInMemRepo(IMapper mapper)
    {
        _mapper = mapper;
    }

    public async Task<ImageDto> GetImageByGuid(string guid)
    {
        return await Task.FromResult(_mapper.Map<ImageDto>(_images.SingleOrDefault(i => i.ImageGuid.Equals(guid, StringComparison.OrdinalIgnoreCase))));
    }

    public async Task<bool> SaveImageAsync(ImageDto imageDtoToSave)
    {
        _images.Add(_mapper.Map<Image>(imageDtoToSave));
        return await SaveAsync();
    }

    public async Task<bool> RemoveImageAsync(string guid)
    {
        var index = _images.FindIndex(i => i.ImageGuid.Equals(guid, StringComparison.OrdinalIgnoreCase));

        if (index < 0)
            return await Task.FromResult(false);

        _images.RemoveAt(index);
        return await SaveAsync();
    }

    public async Task<IEnumerable<ImageDto>> GetAllAsync()
    {
        return await Task.FromResult(_mapper.Map<List<ImageDto>>(_images));
    }

    public Task<ImageDto> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> IsExistsAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> CreateAsync(ImageDto entity)
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateAsync(ImageDto entity)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> SaveAsync()
    {
        throw new NotImplementedException();
    }
}
