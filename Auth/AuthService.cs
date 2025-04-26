using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace LibraryApi.Auth;

public class AuthService
{
    private readonly string _apiKeySecret;
    private readonly List<User> _usuarios = new List<User>()
    {
        new User { Id = 1, UserName = "fabio", Password = "password123" }
    };

    public AuthService(string apiKeySecret)
    {
        _apiKeySecret = apiKeySecret;
    }

    public string Athenticate(LoginDto loginDto)
    {
        var user = _usuarios.FirstOrDefault(
            u => u.UserName.Equals(loginDto.UserName, StringComparison.OrdinalIgnoreCase)
            && u.Password == loginDto.Password);

        if (user == null)
        {
            return null;
        }

        return GenerateTokenJwt(user);
    }

    private string GenerateTokenJwt(User user)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_apiKeySecret);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new Claim[]
            {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(ClaimTypes.PrimarySid, user.Id.ToString())
            }),
            Expires = DateTime.UtcNow.AddMinutes(30),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}
