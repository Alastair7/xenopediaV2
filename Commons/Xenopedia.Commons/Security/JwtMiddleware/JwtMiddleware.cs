using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Xenopedia.Commons.Security.Auth;

namespace Xenopedia.Commons.Security.JwtMiddleware
{
    public class JwtMiddleware : IJwtMiddleware
    {
        private readonly RequestDelegate next;

        public JwtMiddleware (RequestDelegate next) 
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context, IAuthManager authManager)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            var userId = authManager.ValidateToken(token);

            if (userId != null) 
            {
                context.Items["AppId"] = "AppId";
            }

            await next(context);
        }
    }

    public static class JwtMidlewareExtensions
    {
        public static IApplicationBuilder UseJwtMiddleware(this IApplicationBuilder app)
        {
            return app.UseMiddleware<JwtMiddleware>();
        }
    }
}
