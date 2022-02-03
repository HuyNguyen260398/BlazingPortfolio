namespace API.Services;

public class TokenService : ITokenService
{
    public async Task<string> BuildToken(string key, string issuer, string audience, UserDto user)
    {
        var claims = new[]
        {
            new Claim(ClaimTypes.Name, user.FirstName),
            new Claim(ClaimTypes.NameIdentifier, Guid.NewGuid().ToString())
        };

        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));

        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var tokenDescriptor = new JwtSecurityToken(issuer, audience, claims, expires: DateTime.Now.AddDays(60), notBefore: DateTime.UtcNow, signingCredentials: credentials);

        var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);

        return await Task.FromResult(tokenString);
    }
}
