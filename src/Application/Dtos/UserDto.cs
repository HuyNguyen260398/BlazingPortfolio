namespace Application.Dtos;

public class UserDto
{
    public int UserId { get; set; }

    [Required]
    public string FirstName { get; set; }

    [Required]
    public string LastName { get; set; }

    [Required]
    public DateTime DoB { get; set; }

    [Required]
    public string Gender { get; set; }

    [Required]
    public string Email { get; set; }

    [Required]
    public string Password { get; set; }

    [Required]
    public string Phone { get; set; }

    [Required]
    public string Address { get; set; }

    [Required]
    public string Study { get; set; }

    [Required]
    public string Degree { get; set; }

    [Required]
    public string Interests { get; set; }

    public string Intro { get; set; }

    public string AvatarImagePath { get; set; }

    public string BackgroundImagePath { get; set; }
}
