namespace API.Interfaces;

public interface ITokenService
{
    Task<string> BuildToken(string key, string issuer, string audience, UserDto user);
}
