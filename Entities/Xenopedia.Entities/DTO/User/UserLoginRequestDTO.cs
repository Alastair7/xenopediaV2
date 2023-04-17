using Newtonsoft.Json;

namespace Xenopedia.Entities.DTO.User
{
    public class UserLoginRequestDTO
    {
        [JsonProperty("username")]
        public string Username { get; set; } = string.Empty;

        [JsonProperty("password")]
        public string Password { get; set; } = string.Empty;
    }
}
