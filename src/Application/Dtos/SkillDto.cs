namespace Application.Dtos;

public class SkillDto
{
    [Key]
    public int SkillId { get; set; }

    [Required]
    public string Name { get; set; }

    public int YearsOfExperience { get; set; }

    public decimal ScorePercentage { get; set; }
}
