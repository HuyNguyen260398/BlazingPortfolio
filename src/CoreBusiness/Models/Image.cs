namespace CoreBusiness.Models;

public class Image
{
    [Key]
    public int ImageId { get; set; }

    public string ImageGuid { get; set; }

    [Required]
    public string NewImageExtension { get; set; }

    [Required]
    public string NewImageBase64Content { get; set; }

    public string OldImagePath { get; set; }

    public string RelativeImagePath { get; set; }
}
