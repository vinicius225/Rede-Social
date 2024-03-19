
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Rede.Social.Server.Aplication;

namespace Rede.Social.Server.WebApi;

[ApiController]
[Route("[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }
    [Authorize]
    [HttpGet]
    public IActionResult Get()
    {
        return Ok("Funcionsou");
    }
    [HttpPost]
    [Route ("login")]
    public async Task<IActionResult> Login(UserLoginRequestDTO dto)
    {
        try
        {
            return Ok(await _authService.UserLogin(dto));
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}
