namespace Application.Dtos;

public class UserDto
{
    public int UserId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DoB { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Address { get; set; }
    public string Study { get; set; }
    public string Degree { get; set; }
    public string Interests { get; set; }
    public string Intro { get; set; }
    public string AvatarImagePath { get; set; }
    public string BackgroundImagePath { get; set; }
}
