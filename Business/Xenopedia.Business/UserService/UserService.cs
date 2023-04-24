using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Xenopedia.Entities.DTO.User;
using Xenopedia.Entities.Entity.User;

namespace Xenopedia.Business.UserService
{
    public class UserService : IUserService
    {
        public Task<UserDTO> AuthenticateUser(UserLoginRequestDTO loginRequest)
        {
            // Compare Login Request With User Data from DB
            
            // If exists return UserDTO
            throw new NotImplementedException();
        }

        public string GenerateUserToken(UserDTO user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("JWT KEY"));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.Name, user.UserName)
            };

            var token = new JwtSecurityToken(
                "Issuer",
                "Audience",
                claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: credentials
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
