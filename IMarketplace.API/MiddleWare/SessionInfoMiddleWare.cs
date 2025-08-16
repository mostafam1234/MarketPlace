using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Security.Claims;

namespace Marketplace.API.MiddleWare
{
    public class SessionInfoMiddleWare
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<SessionInfoMiddleWare> _logger;

        public SessionInfoMiddleWare(RequestDelegate next, ILogger<SessionInfoMiddleWare> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, [FromServices] UserSession userSession)
        {
            try
            {
                // Debug information
                _logger.LogInformation("SessionInfoMiddleWare executing for path: {Path}", context.Request.Path);
                _logger.LogInformation("User authenticated: {IsAuthenticated}", context.User.Identity?.IsAuthenticated);
                _logger.LogInformation("User identity name: {UserName}", context.User.Identity?.Name);
                _logger.LogInformation("Authentication type: {AuthType}", context.User.Identity?.AuthenticationType);
                
                // Log all claims for debugging
                if (context.User.Claims.Any())
                {
                    _logger.LogInformation("User claims found: {ClaimCount}", context.User.Claims.Count());
                    foreach (var claim in context.User.Claims)
                    {
                        _logger.LogInformation("Claim: {Type} = {Value}", claim.Type, claim.Value);
                    }
                }
                else
                {
                    _logger.LogWarning("No user claims found");
                }

                // Check if user is authenticated
                if (context.User.Identity?.IsAuthenticated == true)
                {
                    // Extract tenant ID from JWT token claims
                    var tenantIdClaim = context.User.Claims.FirstOrDefault(x => x.Type.Equals("TenantId", StringComparison.OrdinalIgnoreCase))?.Value;
                    var userId = context.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value ?? string.Empty;
                    var email = context.User.Claims.FirstOrDefault(x => x.Type.Equals(ClaimTypes.Email))?.Value ?? "";
                    var roles = context.User.Claims.Where(x => x.Type == ClaimTypes.Role).Select(x => x.Value).ToList();

                    _logger.LogInformation("Extracted claims - TenantId: {TenantId}, UserId: {UserId}, Email: {Email}", 
                        tenantIdClaim, userId, email);

                    // Set default tenant ID if not found
                    if (string.IsNullOrEmpty(tenantIdClaim) || !int.TryParse(tenantIdClaim, out var parsedTenantId))
                    {
                        parsedTenantId = 0; // Default tenant ID
                        _logger.LogWarning("No valid TenantId found in JWT token, using default tenant ID: {DefaultTenantId}", parsedTenantId);
                    }

                    if (int.TryParse(userId, out var parsedUserId))
                    {
                        userSession.TenantId = parsedTenantId;
                        userSession.UserId = parsedUserId;
                        userSession.Email = email;
                        userSession.Role = roles.FirstOrDefault() ?? string.Empty;

                        _logger.LogInformation("Session info set successfully - TenantId: {TenantId}, UserId: {UserId}, Email: {Email}", 
                            parsedTenantId, parsedUserId, email);
                    }
                    else
                    {
                        _logger.LogWarning("No valid UserId found in JWT token");
                    }
                }
                else
                {
                    _logger.LogWarning("User is not authenticated. This might be a public endpoint or authentication failed.");
                    
                    // For debugging, check if Authorization header exists
                    var authHeader = context.Request.Headers["Authorization"].FirstOrDefault();
                    if (!string.IsNullOrEmpty(authHeader))
                    {
                        _logger.LogInformation("Authorization header found: {AuthHeader}", authHeader.Substring(0, Math.Min(20, authHeader.Length)) + "...");
                    }
                    else
                    {
                        _logger.LogInformation("No Authorization header found");
                    }
                }

                context.Items["UserSession"] = userSession;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while processing session info middleware");
            }

            await _next(context);
        }
    }
}
