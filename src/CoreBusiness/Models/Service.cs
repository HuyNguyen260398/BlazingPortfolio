namespace CoreBusiness.Models;

public class Service
{
    [Key]
    public int ServiceId { get; set; }

    [Required]
    public string Name { get; set; }

    public string Description { get; set; }

    public string DisplayIcon { get; set; }
}
