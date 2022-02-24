namespace Application.Dtos;

public class PostDto
{
    public int PostId { get; set; }

    [Required]
    public string Title { get; set; }

    public string ThumbnailPath { get; set; }

    public int ImageId { get; set; }

    [Required]
    public string Excerpt { get; set; }

    [Required]
    public string Content { get; set; }

    public bool IsPublished { get; set; }

    public DateTime PublishDate { get; set; }
}
