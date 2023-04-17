using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Xenopedia.Business.UserService;
using Xenopedia.Entities.DTO.User;

namespace Xenopedia.Service.Controllers
{
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;

        public UserController(IUserService userService) 
        {
            this.userService = userService;
        }

        [AllowAnonymous]
        [HttpPost("LoginUser")]
        public async Task<IActionResult> Login([FromBody] UserLoginRequestDTO loginRequest)
        {
            UserDTO user = await userService.AuthenticateUser(loginRequest);

            if (user == null) 
            {
                return new BadRequestResult();
            }

            string token = userService.GenerateUserToken(user);

            return Ok(token);
        }
    }
}
