using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Xenopedia.Entities.DTO.User;

namespace Xenopedia.Service.Controllers
{
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        [AllowAnonymous]
        [HttpPost("LoginUser")]
        public async Task<IActionResult> Login([FromBody] UserLoginRequestDTO loginRequest)
        {
            // Authenticate User

            // If auth is SUCCESS generate TOKEN

            return Ok(string.Empty);
        }
    }
}
