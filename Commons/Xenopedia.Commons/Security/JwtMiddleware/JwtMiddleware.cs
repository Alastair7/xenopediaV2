using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xenopedia.Commons.Security.Auth;

namespace Xenopedia.Commons.Security.JwtMiddleware
{
    public class JwtMiddleware : IJwtMiddleware
    {
        private readonly RequestDelegate next;

        public JwtMiddleware(RequestDelegate next) 
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context, IUserService userService, IAuthManager authManager)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            var userId = authManager.ValidateToken(token);

            if (userId != null) 
            {
                context.Items["User"] = userService.GetUser(userId.Value);
            }

            await next(context);
        }
    }
}
