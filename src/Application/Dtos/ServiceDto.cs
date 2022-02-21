namespace Application.Dtos;

public class ServiceDto
{
    public int ServiceId { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    public string Description { get; set; }

    public string DisplayIcon { get; set; }
}
