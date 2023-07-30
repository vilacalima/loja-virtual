using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using login.DTO;
using login.UserService;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly IConfiguration _configuration;
    private readonly IUserService _userService;

    public AuthController(IConfiguration configuration,
                            IUserService userService)
    {
        _configuration = configuration;
        _userService = userService;
    }

    [HttpPost]
    public IActionResult Authenticate([FromBody] UserDTO? user)
    {
        if(user != null)
        {
            if (_userService.IsValidUser(user.Email, user.Senha))
            {
                var jwtAuthenticationManager = new JwtAuthenticationManager(_configuration["Jwt:SecretKey"]);
                var token = jwtAuthenticationManager.GenerateToken(user.Email);

                return Ok(new { Token = token });
            }
        }
        
        return Unauthorized();
    }
}
