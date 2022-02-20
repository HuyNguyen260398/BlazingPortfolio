namespace Infrastructure.SqliteDb;

public class ImageRepo : IImageRepo
{
    private readonly AppDbContext _db;
    private readonly IMapper _mapper;

    public ImageRepo(AppDbContext db, IMapper mapper)
    {
        _db = db;
        _mapper = mapper;
    }

    public Task<bool> CreateAsync(ImageDto entity)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var imageToDelete = await _db.Images.FindAsync(id);

        if (imageToDelete == null)
            return false;

        _db.Images.Remove(imageToDelete);
        return await _db.SaveChangesAsync() > 0;
    }

    public async Task<IEnumerable<ImageDto>> GetAllAsync()
    {
        return _mapper.Map<IEnumerable<ImageDto>>(await _db.Images.ToListAsync());
    }

    public async Task<ImageDto> GetByIdAsync(int id)
    {
        return _mapper.Map<ImageDto>(await _db.Images.FindAsync(id));
    }

    public async Task<ImageDto> GetImageByGuid(string guid)
    {
        return _mapper.Map<ImageDto>(await _db.Images.SingleOrDefaultAsync(x => x.ImageGuid.Equals(guid, StringComparison.OrdinalIgnoreCase)));
    }

    public Task<bool> IsExistsAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> RemoveImageAsync(string guid)
    {
        var imageToDelete = await _db.Images.SingleOrDefaultAsync(x => x.ImageGuid.Equals(guid, StringComparison.OrdinalIgnoreCase));

        if (imageToDelete == null)
            return false;

        _db.Images.Remove(imageToDelete);
        return await _db.SaveChangesAsync() > 0;
    }

    public Task<bool> SaveAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<bool> SaveImageAsync(ImageDto imageDtoToSave)
    {
        if (imageDtoToSave == null)
            return false;

        await _db.Images.AddAsync(_mapper.Map<Image>(imageDtoToSave));
        return await _db.SaveChangesAsync() > 0;
    }

    public Task<bool> UpdateAsync(ImageDto entity)
    {
        throw new NotImplementedException();
    }
}
