using Microsoft.AspNetCore.Mvc;
using StudentsPortalApp.Services;
using StudentsPortalApp.StudentModel;

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

        [HttpPost]
        [ApiVersion("1.0")]
        [Route("Validate")]
        public async Task<ActionResult<string>> ValidateUser([FromBody] Login login)
        {
            _logger.LogInformation("User Validation Process started");
            var result = await _loginService.ValidateUser(login);
            if (result.Item1 == 200)
            {
                return Ok(result.Item2);
            }
            return Unauthorized(result.Item2);
        }
    }
}
