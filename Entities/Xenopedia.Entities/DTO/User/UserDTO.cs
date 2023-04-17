using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xenopedia.Entities.DTO.User
{
    public class UserDTO
    {
        [JsonProperty("idUser")]
        public int IdUser { get; set; }

        [JsonProperty("username")]
        public string UserName { get; set; } = string.Empty;

        [JsonProperty("password")]
        public string Password { get; set; } = string.Empty;

        [JsonProperty("creationDate")]
        public DateTime? CreationDate { get; set; }

    }
}
