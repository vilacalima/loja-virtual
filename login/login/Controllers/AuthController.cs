using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using login.UserDTO;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly IConfiguration _configuration;

    public AuthController(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    [HttpPost]
    public IActionResult Authenticate([FromBody] UserDTO user)
    {
        var jwtAuthenticationManager = new JwtAuthenticationManager(_configuration["Jwt:SecretKey"]);
        if (jwtAuthenticationManager.Authenticate(user.Email, user.Senha))
        {
            var token = jwtAuthenticationManager.GenerateToken(user.Email);
            return Ok(new { Token = token });
        }

        return Unauthorized();
    }
}
