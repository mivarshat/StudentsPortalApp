using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using StudentsPortalApp.EFContext;
using StudentsPortalApp.StudentModel;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace StudentsPortalApp.Services
{
    public class LoginService : ILoginService
    {
        private readonly StudentInformationlDBContext _studentdbContext;
        private readonly ILogger<LoginService> _logger;
        private readonly IConfiguration _configuration;

        public LoginService(StudentInformationlDBContext studentService, ILogger<LoginService> logger,IConfiguration configuration)
        {
            _studentdbContext = studentService;
            _logger = logger;
            _configuration = configuration;
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

        public async Task<(int,string)> ValidateUser(Login login)
        {

            try
            {
                var validUser = await _studentdbContext.Login.FirstOrDefaultAsync(x => x.UserName == login.UserName && x.Password == login.Password);
                if(validUser != null)
                {
                    var token = IssueToken(login);
                    return (StatusCodes.Status200OK, token);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return (StatusCodes.Status401Unauthorized, "Invalid User Name or Password");
        }
        private string IssueToken(Login login)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new List<Claim>
            {
                new Claim("Myapp_User_Id",login.UserName),
                new Claim (ClaimTypes.NameIdentifier,login.UserName)
            };

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: credentials
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
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
