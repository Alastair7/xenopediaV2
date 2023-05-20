using Xenopedia.Entities.DTO.User;

namespace Xenopedia.Business.UserService
{
    public interface IUserService
    {
        Task<UserDTO> AuthenticateUser(UserLoginRequestDTO loginRequest);

        string GenerateUserToken(UserDTO user);
    }
}
