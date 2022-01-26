namespace CoreBusiness.Models;

public class Image
{
    public string ImageGuid { get; set; }
    public string NewImageExtension { get; set; }
    public string NewImageBase64Content { get; set; }
    public string OldImagePath { get; set; }
    public string RelativeImagePath { get; set; }
}
