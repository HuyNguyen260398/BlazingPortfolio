﻿namespace API.Endpoints;

public class PostEndpoints : IEndpoint
{
    private readonly IPostController _postController;

    public PostEndpoints(IPostController postController)
    {
        _postController = postController;
    }

    public void AddRoute(IEndpointRouteBuilder app)
    {
        app.MapGet("/api/posts", async () => await _postController.GetAll()).WithTags("Post");
        app.MapGet("/api/posts/{id}", async (int id) => await _postController.GetById(id)).WithTags("Post");
        app.MapPost("/api/posts", async (PostDto postDto) => await _postController.Create(postDto)).WithTags("Post");
        app.MapPut("/api/posts", async (PostDto postDto) => await _postController.Update(postDto)).WithTags("Post");
        app.MapDelete("/api/posts/{id}", async (int id) => await _postController.Delete(id)).WithTags("Post");
    }
}
