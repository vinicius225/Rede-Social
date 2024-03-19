
using Rede.Social.Server.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Rede.Social.Server.Aplication;

public class AuthService : IAuthService
{
    private readonly IUserRepository _userRepository;
    private readonly IConfiguration _configuration;

    public AuthService(IUserRepository userRepository, IConfiguration configuration)
    {
        _userRepository = userRepository;
        _configuration = configuration;
    }

    public async Task<UserLoginResponseDTO> UserLogin(UserLoginRequestDTO userLogin)
    {
        try
        {
            await _userRepository.GetAll(1, 1);

            return new UserLoginResponseDTO
            {
                Login = "teste",
                DateExpiration = DateTime.Now.AddHours(1),
                Name = "johnw senna",
                Token = GenerateToken()
            };
        }
        catch (Exception ex)
        {

            return new UserLoginResponseDTO
            {
                Login = "teste",
                DateExpiration = DateTime.Now.AddHours(1),
                Name = "johnw senna",
                Token = GenerateToken()
            };
        }
    }

private string GenerateToken()
{
    var issuer = _configuration["JwtSettings:Issuer"];
    var secret = _configuration["JwtSettings:Secret"];


    var tokenHandler = new JwtSecurityTokenHandler();
    var key = Encoding.ASCII.GetBytes(secret);
    var tokenDescriptor = new SecurityTokenDescriptor
    {
        Subject = new ClaimsIdentity(new Claim[]
        {
            new Claim(ClaimTypes.Email, "jj"),
        }),
        Expires = DateTime.UtcNow.AddMinutes(Convert.ToInt32(_configuration["JwtSettings:ExpirationMinutes"])),
        Issuer = issuer,
        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
    };
    var token = tokenHandler.CreateToken(tokenDescriptor);
    return tokenHandler.WriteToken(token);
}
}
