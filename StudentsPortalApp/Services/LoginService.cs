using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentsPortalApp.EFContext;
using StudentsPortalApp.StudentModel;

namespace StudentsPortalApp.Services
{
    public class LoginService : ILoginService
    {
        private readonly StudentInformationlDBContext _studentdbContext;
        private readonly ILogger<LoginService> _logger;

        public LoginService(StudentInformationlDBContext studentService,ILogger<LoginService> logger)
        {
            _studentdbContext = studentService;
            _logger = logger;
        }

        public async Task<ActionResult<string>> RegisterUser(int rollNo)
        {
            try
            {
                var studentPersonalDetails = ValidateUser(rollNo).Result;
                if (studentPersonalDetails != null)
                {
                    _logger.LogInformation($"Personal details for {studentPersonalDetails.Name} found");
                    var loginAccess = new Login()
                    {
                        UserName = studentPersonalDetails.Name,
                        Password = studentPersonalDetails.Name + studentPersonalDetails.RollNo.ToString()
                    };

                    var registered = await _studentdbContext.Login.AddAsync(loginAccess);
                    await _studentdbContext.SaveChangesAsync();

                    return $"{studentPersonalDetails.Name} Registered successfully";
                }
                _logger.LogInformation($"Personal details for {studentPersonalDetails.Name} does not found");
                return $"{studentPersonalDetails.Name} does Not Exist";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public async Task<string> UnRegisterUser(int rollNo)
        {
            try
            {
                var studentPersonalDetails = ValidateUser(rollNo).Result;

                if (studentPersonalDetails != null)
                {
                    _logger.LogInformation($"Personal details for {studentPersonalDetails.Name} found");

                    var validUser = await _studentdbContext.Login.FirstOrDefaultAsync(x => x.UserName == studentPersonalDetails.Name);
                    if (validUser != null)
                    {
                        _logger.LogInformation($"login information for {studentPersonalDetails.Name} found");
                        var registered = _studentdbContext.Login.Remove(validUser);
                        await _studentdbContext.SaveChangesAsync();
                        return $"{studentPersonalDetails.Name} Unregistered successfully";
                    }
                    _logger.LogInformation($"login information for {studentPersonalDetails.Name} does not found");

                }
                _logger.LogInformation($"Personal details for {studentPersonalDetails.Name} does not found");
                return $"{studentPersonalDetails.Name} Not Found";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        private async Task<StudentPersonalDetails> ValidateUser(int rollNo)
        {
            StudentPersonalDetails studentPersonalDetails = new StudentPersonalDetails();

            try
            {
                studentPersonalDetails = await _studentdbContext.StudentPersonalDetails.FirstOrDefaultAsync(x => x.RollNo == rollNo);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message); 
            }
            return studentPersonalDetails;
        }
    }
}
