namespace API.Controllers;

public class PostController : BaseController<PostDto>, IPostController
{
    private readonly IPostRepo _postRepo;

    public PostController(IPostRepo postRepo) : base(postRepo)
    {
        _postRepo = postRepo;
    }
}
