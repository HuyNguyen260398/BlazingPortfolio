namespace Application.Dtos;

public class ArchievementDto
{
    public int ArchievementId { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    public int Count { get; set; }
}
