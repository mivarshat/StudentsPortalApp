using Azure;
using Microsoft.AspNetCore.Mvc;
using StudentsPortalApp.Services;

namespace StudentsPortalApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : Controller
    {
        private readonly ILoginService _loginService;
        private readonly ILogger<LoginController> _logger;

        public LoginController(ILoginService loginService, ILogger<LoginController> logger)
        {
            _loginService = loginService;
            _logger = logger;
        }

        [HttpPost]
        [ApiVersion("1.0")]
        [Route("Register")]
        public async Task<ActionResult<string>> RegisterUser([FromBody] int rollNo)
        {
            _logger.LogInformation("User Registration Process started");
            var result = _loginService.RegisterUser(rollNo).Result;
            return result;
        }

        [HttpPatch]
        [ApiVersion("1.0")]
        [Route("UnRegister")]
        public string UnRegisterUser([FromBody] int rollNo)
        {
            _logger.LogInformation("User un-registration Process started");
            var result = _loginService.UnRegisterUser(rollNo).Result;
            return result;
        }
    }
}
