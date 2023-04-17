using Xenopedia.Entities.DTO.User;

namespace Xenopedia.Business.UserService
{
    public class UserService : IUserService
    {
        public Task<UserDTO> AuthenticateUser(UserLoginRequestDTO loginRequest)
        {
            throw new NotImplementedException();
        }

        public Task<string> GenerateUserToken(UserDTO user)
        {
            throw new NotImplementedException();
        }
    }
}
