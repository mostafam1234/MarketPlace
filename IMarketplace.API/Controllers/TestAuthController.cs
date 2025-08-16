using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Domain.Interfaces;
using Application.Services.Auth.Commands;
using Application.Services.Auth.Dto;
using Domain.Interfaces.IServiceManager;
using Infrastructure.Data;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace IMarketplace.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestAuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IUserSessionProvider _userSessionProvider;
        private readonly ILogger<TestAuthController> _logger;
        private readonly MarketPlaceContext marketPlaceContext;

        public TestAuthController(
            IAuthService authService,
            IUserSessionProvider userSessionProvider,
            ILogger<TestAuthController> logger,
            MarketPlaceContext marketPlaceContext)
        {
            _authService = authService;
            _userSessionProvider = userSessionProvider;
            _logger = logger;
            this.marketPlaceContext = marketPlaceContext;
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login([FromBody] LoginDto loginDto)
        {
            try
            {
                var result = await _authService.LoginAsync(loginDto);
                _logger.LogInformation("Login successful for user: {Email}", loginDto.Email);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Login failed for user: {Email}", loginDto.Email);
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> Register([FromBody] RegisterDto registerDto)
        {
            try
            {
                var result = await _authService.RegisterAsync(registerDto);
                _logger.LogInformation("Registration successful for user: {Email}", registerDto.Email);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Registration failed for user: {Email}", registerDto.Email);
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpGet("test-auth")]
        [Authorize]
        public async Task<ActionResult<object>> TestAuth()
        {
            var userSession = _userSessionProvider;

            var test = await marketPlaceContext.Products.ToListAsync();
            
            return Ok(new
            {
                Message = "Authentication successful!",
                UserId = userSession.UserId,
                TenantId = userSession.TenantId,
                Email = userSession.Email,
                Role = userSession.Role,
                IsAuthenticated = User.Identity?.IsAuthenticated,
                UserName = User.Identity?.Name,
                AuthenticationType = User.Identity?.AuthenticationType,
                Claims = User.Claims.Select(c => new { c.Type, c.Value }).ToList()
            });
        }

        [HttpGet("public")]
        public ActionResult<object> PublicEndpoint()
        {
            return Ok(new
            {
                Message = "This is a public endpoint",
                IsAuthenticated = User.Identity?.IsAuthenticated,
                UserName = User.Identity?.Name,
                CurrentTime = DateTime.UtcNow
            });
        }
    }
} 