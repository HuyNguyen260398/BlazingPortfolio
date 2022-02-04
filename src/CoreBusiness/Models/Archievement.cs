namespace CoreBusiness.Models;

public class Archievement
{
    [Key]
    public int ArchievementId { get; set; }
    public string Name { get; set; }
    public int Count { get; set; }
}
