﻿namespace CoreBusiness.Models;

public class Post
{
    public int PostId { get; set; }
    public string Title { get; set; }
    public string ThumbnailPath { get; set; }
    public string Excerpt { get; set; }
    public string Content { get; set; }
    public bool IsPublished { get; set; }
    public DateTime PublishDate { get; set; }
    public string Author { get; set; }
}