namespace CoreBusiness.Models;

public class Archievement
{
    [Key]
    public int ArchievementId { get; set; }

    [Required]
    public string Name { get; set; }

    public int Count { get; set; }
}
