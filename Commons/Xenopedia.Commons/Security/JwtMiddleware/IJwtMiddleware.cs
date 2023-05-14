using Microsoft.AspNetCore.Http;
using Xenopedia.Commons.Security.Auth;

namespace Xenopedia.Commons.Security.JwtMiddleware
{
    public interface IJwtMiddleware
    {
        Task Invoke(HttpContext context, IUserService userService, IAuthManager authManager);
    }
}
