using LibraryApi.Auth;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly AuthService _authService;

    public AuthController(AuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginDto loginDto)
    {
        var token = _authService.Athenticate(loginDto);

        if (token == null)
        {
            return Unauthorized(new { message = "Invalid Credencials" });
        }

        return Ok(new { token });
    }
}
