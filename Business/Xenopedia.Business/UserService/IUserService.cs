using Xenopedia.Entities.DTO.User;

namespace Xenopedia.Business.UserService
{
    public interface IUserService
    {
        Task<UserDTO> AuthenticateUser(UserLoginRequestDTO loginRequest);

        Task<string> GenerateUserToken(UserDTO user);
    }
}
