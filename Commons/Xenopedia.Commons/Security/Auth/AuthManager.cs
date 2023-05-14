using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Xenopedia.Commons.Security.Auth
{
    public class AuthManager : IAuthManager
    {
        private readonly IConfiguration configuration;

        public AuthManager(IConfiguration configuration) 
        {
            this.configuration = configuration;
        }

        public string GenerateToken(string username, string password)
        {
            bool isValid = ValidateCredentials(username, password);

            if (!isValid) 
            {
                throw new Exception("Invalid User Credentials");
            }

            var tokenHandler = new JwtSecurityTokenHandler();

            var tokenKey = Encoding.UTF8.GetBytes(configuration["Jwt:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, username),
                }),
                Expires = DateTime.Now.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
            };

            var token =  tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
            
        }

        public int? ValidateToken(string token)
        {
            if (token == null) return null;

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(token); // Change token by app secrets.

            try 
            {
                tokenHandler.ValidateToken(token, new TokenValidationParameters 
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                var jwtToken = validatedToken as JwtSecurityToken;
                int userId = int.Parse(jwtToken.Claims.First(x => x.Type.Equals("id")).Value);

                return userId;
            }
            catch 
            {
                return null;
            }
        }

        private bool ValidateCredentials(string username, string password) 
        {
            bool isValid = true;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password)) { isValid = false; }

            // Get Users from DB and check if User exists

            // Check if password is correct

            return isValid;
        }
    }
}
