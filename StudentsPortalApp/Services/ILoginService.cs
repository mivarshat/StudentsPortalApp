using StudentsPortalApp.StudentModel;

namespace StudentsPortalApp.Services
{
    public interface ILoginService
    {
        public Task<string> RegisterUser(int rollNo);
        public Task<string> UnRegisterUser(int rollNo);
        public Task<StudentPersonalDetails> ValidateUser(int rollNo);
    }
}
