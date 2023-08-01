using login.DTO;
using login.UserService;
using Microsoft.AspNetCore.Mvc;

namespace login.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public IActionResult CreateUser([FromBody] UserDTO userDTO)
        {
            try
            {
                var user = UserMapHelpers.UserMap(userDTO);
                _userService.RegisterNewUser(user);

                return Ok(userDTO);
            } catch
            {
                throw;
            }
        }
    }
}
