namespace Infrastructure.InMemDb;

public class PostInMemRepo : IPostRepo
{
    private static List<Post> _posts = new()
    {
        new Post 
        { 
            PostId = 1, 
            Title = "Post 1", 
            ThumbnailPath = String.Empty, 
            Excerpt = "Excerpt 1", 
            Content = "Content 1", 
            IsPublished = true, 
            PublishDate = DateTime.Now.Date
        },
        new Post
        {
            PostId = 2,
            Title = "Post 2",
            ThumbnailPath = String.Empty,
            Excerpt = "Excerpt 2",
            Content = "Content 2",
            IsPublished = true,
            PublishDate = DateTime.Now.Date
        },
        new Post
        {
            PostId = 3,
            Title = "Post 3",
            ThumbnailPath = String.Empty,
            Excerpt = "Excerpt 3",
            Content = "Content 3",
            IsPublished = true,
            PublishDate = DateTime.Now.Date
        },
    };

    private readonly IMapper _mapper;

    public PostInMemRepo(IMapper mapper)
    {
        _mapper = mapper;
    }

    public async Task<IEnumerable<PostDto>> GetAllAsync()
    {
        return await Task.FromResult(_mapper.Map<List<PostDto>>(_posts));
    }

    public async Task<PostDto> GetByIdAsync(int id)
    {
        return await Task.FromResult(_mapper.Map<PostDto>(_posts.Find(p => p.PostId == id)));
    }

    public async Task<bool> IsExistsAsync(int id)
    {
        return await Task.FromResult(_posts.Any(p => p.PostId == id));
    }

    public async Task<bool> CreateAsync(PostDto serviceDtoToCreate)
    {
        var serviceToCreate = _mapper.Map<Post>(serviceDtoToCreate);

        if (_posts.Any(p => p.Title.Equals(serviceToCreate.Title, StringComparison.OrdinalIgnoreCase)))
            return await Task.FromResult(false);

        if (_posts != null && _posts.Count > 0)
            serviceToCreate.PostId = _posts.Max(p => p.PostId) + 1;
        else
            serviceToCreate.PostId = 1;

        _posts.Add(serviceToCreate);
        return await SaveAsync();
    }

    public async Task<bool> UpdateAsync(PostDto serviceDtoToUpdate)
    {
        var serviceToUpdate = _mapper.Map<Post>(serviceDtoToUpdate);

        var index = _posts.FindIndex(p => p.PostId == serviceToUpdate.PostId);

        if (index < 0)
            return await Task.FromResult(false);

        _posts[index] = serviceToUpdate;
        return await SaveAsync();
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var index = _posts.FindIndex(p => p.PostId == id);

        if (index < 0)
            return await Task.FromResult(false);

        _posts.RemoveAt(index);
        return await SaveAsync();
    }

    public async Task<bool> SaveAsync()
    {
        return await Task.FromResult(true);
    }
}
