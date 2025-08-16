using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Domain.Interfaces;
using Domain.Interfaces.IServiceManager;

namespace IMarketplace.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet("authenticated")]
        [Authorize]
        public IActionResult GetAuthenticated([FromServices] IUserSessionProvider userSession)
        {
            return Ok(new
            {
                Message = "You are authenticated!",
                UserId = userSession.UserId,
                TenantId = userSession.TenantId,
                Email = userSession.Email,
                Role = userSession.Role,
                IsAuthenticated = User.Identity?.IsAuthenticated,
                UserName = User.Identity?.Name,
                Claims = User.Claims.Select(c => new { c.Type, c.Value }).ToList()
            });
        }

        [HttpGet("public")]
        public IActionResult GetPublic()
        {
            return Ok(new
            {
                Message = "This is a public endpoint",
                IsAuthenticated = User.Identity?.IsAuthenticated,
                UserName = User.Identity?.Name
            });
        }
    }
}
