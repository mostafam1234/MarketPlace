using Domain.Interfaces.IServiceManager;
using Microsoft.AspNetCore.Mvc;

namespace Marketplace.API.Controllers
{
    public class TestController : Controller
    {
        private readonly IUserSessionProvider _userSessionProvider;

        public TestController(IUserSessionProvider userSessionProvider)
        {
            _userSessionProvider = userSessionProvider;
        }
        //[HttpGet("test")]
        //public IActionResult GetCurrentUserSession()
        //{
        //    var result = new
        //    {
        //        UserId = _userSessionProvider.UserId,
        //        TenantId = _userSessionProvider.TenantId,
        //        Email = _userSessionProvider.Email,
        //        Role = _userSessionProvider.Role
        //    };

        //    return Ok(result);
        //}
    }
}
