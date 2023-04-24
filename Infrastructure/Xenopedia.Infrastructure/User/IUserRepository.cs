using Xenopedia.Entities.Entity.User;

namespace Xenopedia.Infrastructure.User
{
    public interface IUserRepository
    {
        Task<UserEntity> GetUser(string username);
    }
}
