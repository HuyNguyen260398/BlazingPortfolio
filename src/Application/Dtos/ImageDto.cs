namespace Application.Dtos;

public class ImageDto
{
    public int ImageId { get; set; }
    public string ImageGuid { get; set; }
    public string NewImageExtension { get; set; }
    public string NewImageBase64Content { get; set; }
    [Required] // for test
    public string OldImagePath { get; set; }
    public string RelativeImagePath { get; set; }
}
