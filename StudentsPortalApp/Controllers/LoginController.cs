using Microsoft.AspNetCore.Mvc;
using StudentsPortalApp.Services;

namespace StudentsPortalApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : Controller
    {
        private readonly ILoginService _loginService;

        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpPost]
        [Route("Register")]
        public string RegisterUser([FromBody] int rollNo)
        {
            var registerUser =  _loginService.RegisterUser(rollNo).Result;
            return registerUser;
        }

        [HttpPatch]
        [Route("UnRegister")]
        public string UnRegisterUser([FromBody] int rollNo)
        {
            var unRegisterUser = _loginService.UnRegisterUser(rollNo).Result;
            return unRegisterUser;
        }
    }
}
