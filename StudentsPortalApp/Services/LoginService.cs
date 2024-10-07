using Microsoft.EntityFrameworkCore;
using StudentsPortalApp.EFContext;
using StudentsPortalApp.StudentModel;

namespace StudentsPortalApp.Services
{
    public class LoginService : ILoginService
    {
        private readonly StudentInformationlDBContext _studentdbContext;

        public LoginService(StudentInformationlDBContext studentService)
        {
            _studentdbContext = studentService;
        }

        public async Task<string> RegisterUser(int rollNo)
        {
            try
            {
                var userExist = ValidateUser(rollNo).Result;
                if (userExist != null)
                {
                    var loginAccess = new Login()
                    {

                        UserName = userExist.Name,
                        Password = userExist.Name + userExist.RollNo.ToString()
                    };

                    var registered = await _studentdbContext.Login.AddAsync(loginAccess);
                    await _studentdbContext.SaveChangesAsync();

                    return "User Registered";
                }
                else
                {
                    return "User Not Exist";

                }


            }
            catch (Exception ex)
            {
            }


            return "User Not Registered";

        }

        public async Task<string> UnRegisterUser(int rollNo)
        {

            try
            {
                var userExist = ValidateUser(rollNo).Result;

                if (userExist != null)
                {
                    var validUser = await _studentdbContext.Login.FirstOrDefaultAsync(x => x.UserName == userExist.Name);
                    if (validUser != null)
                    {
                        var registered = _studentdbContext.Login.Remove(validUser);
                        await _studentdbContext.SaveChangesAsync();

                        return "User UnRegistered";
                    }
                    else
                    {
                        return "User Not Found";
                    }
                }
                else
                {
                    return "User Not Found";
                }

            }
            catch (Exception ex)
            {
            }
            return "User Not UnRegistered";
        }

        public async Task<StudentPersonalDetails> ValidateUser(int rollNo)
        {
            StudentPersonalDetails userExist = new StudentPersonalDetails();

            try
            {
                userExist = await _studentdbContext.StudentPersonalDetails.FirstOrDefaultAsync(x => x.RollNo == rollNo);
            }
            catch (Exception ex)
            {
            }
            return userExist;
        }
    }
}
