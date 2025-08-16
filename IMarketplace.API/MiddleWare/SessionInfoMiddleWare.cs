using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Security.Claims;

namespace Marketplace.API.MiddleWare
{
    public class SessionInfoMiddleWare
    {
        private readonly RequestDelegate _next;
        public SessionInfoMiddleWare(RequestDelegate next)
        {
            _next = next;
       }

        public async Task InvokeAsync(HttpContext context, [FromServices]  UserSession userSession)
        {
            var TenantId = context.User.Claims.FirstOrDefault(x => x.Type.Equals("TenantId"))?.Value ?? "0";
            var userId = context.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value ?? string.Empty;
            var email = context.User.Claims.FirstOrDefault(x => x.Type.Equals(ClaimTypes.Email))?.Value ?? "";
            var roles = context.User.Claims.Where(x => x.Type == ClaimTypes.Role).Select(x => x.Value).ToList(); context.Items["UserSession"] = userSession;

            if (int.TryParse(TenantId, out var parsedTenantId) && int.TryParse(userId, out var parsedUserId))
            {
                userSession.TenantId = parsedTenantId;
                userSession.UserId = parsedUserId;
                userSession.Email = email;
                userSession.Role = roles.FirstOrDefault() ?? string.Empty;
            }
            context.Items["UserSession"] = userSession;
            await _next(context);

        }
    }
}
