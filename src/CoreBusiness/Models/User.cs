namespace CoreBusiness.Models;

[BsonIgnoreExtraElements]
public class User
{
    [Key]
    public int UserId { get; set; }

    [Required]
    public string FirstName { get; set; }

    [Required]
    public string LastName { get; set; }

    public DateTime DoB { get; set; }

    public string Gender { get; set; }

    [Required]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    [DataType(DataType.PhoneNumber)]
    public string Phone { get; set; }

    public string Address { get; set; }

    public string Study { get; set; }

    public string Degree { get; set; }

    public string Interests { get; set; }

    public string Intro { get; set; }

    public string AvatarImagePath { get; set; }

    public string BackgroundImagePath { get; set; }
}
