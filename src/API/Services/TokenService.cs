namespace API.Services;

public class TokenService : ITokenService
{
    private TimeSpan _expiryDuration = new TimeSpan(0, 1, 0, 0);
    public string BuildToken(string key, string issuer, string audience, UserDto user)
    {
        var claims = new[]
        {
            new Claim(ClaimTypes.Name, user.FirstName),
            new Claim(ClaimTypes.NameIdentifier, Guid.NewGuid().ToString())
        };

        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));

        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var tokenDescriptor = new JwtSecurityToken(issuer, audience, claims, expires: DateTime.Now.Add(_expiryDuration), signingCredentials: credentials);

        return new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);
    }
}
