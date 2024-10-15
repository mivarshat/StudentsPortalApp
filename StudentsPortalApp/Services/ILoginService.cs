using Microsoft.AspNetCore.Mvc;
using StudentsPortalApp.StudentModel;

namespace StudentsPortalApp.Services
{
    public interface ILoginService
    {
        public Task<ActionResult<string>> RegisterUser(int rollNo);
        public Task<string> UnRegisterUser(int rollNo);
        public Task<(int, string)> ValidateUser(Login login);
    }
}
