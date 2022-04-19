namespace CoreBusiness.Models;

[BsonIgnoreExtraElements]
public class Archievement
{
    [Key]
    public int ArchievementId { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    public int Count { get; set; }
}
