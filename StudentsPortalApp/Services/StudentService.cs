using Microsoft.EntityFrameworkCore;
using StudentsPortalApp.EFContext;
using StudentsPortalApp.StudentModel;

namespace StudentsPortalApp.Services
{
    public class StudentService : IStudentService
    {
        private readonly StudentInformationlDBContext _studentService;
        private readonly ILogger<StudentService> _logger;

        public StudentService(StudentInformationlDBContext studentService, ILogger<StudentService> logger)
        {
            _studentService = studentService;
            _logger = logger;
        }
       
        public async Task<List<StudentPersonalDetails>> GetStudentPersonalDetails()
        {
            List<StudentPersonalDetails> studentsRecords = new List<StudentPersonalDetails>();

            try
            {
                studentsRecords = await _studentService.StudentPersonalDetails.ToListAsync();
                _logger.LogInformation("Received Student's Personal Details");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return studentsRecords!;
        }

        public async Task<StudentPersonalDetails> GetStudentPersonalDetails(int rollNo)
        {
            StudentPersonalDetails studentPersonalDetails = new StudentPersonalDetails();
            try
            {
                studentPersonalDetails = await _studentService.StudentPersonalDetails.FirstOrDefaultAsync(x => x.RollNo == rollNo);
                _logger.LogInformation($"Received Student's Personal Details for roll no {studentPersonalDetails!.RollNo}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return studentPersonalDetails!;
        }

        public async Task<List<StudentCurriculamDetails>> GetStudentCurriculamDetails()
        {
            List<StudentCurriculamDetails> studentCurriculamDetails = new List<StudentCurriculamDetails>();

            try
            {
                studentCurriculamDetails = await _studentService.StudentCurriculamDetails.ToListAsync();
                _logger.LogInformation("Received Student's Curriculam Details");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return studentCurriculamDetails!;
        }

        public async Task<StudentCurriculamDetails> GetStudentCurriculamDetails(int rollNo)
        {
            StudentCurriculamDetails studentCurriculamDetails = new StudentCurriculamDetails();

            try
            {
                studentCurriculamDetails = await _studentService.StudentCurriculamDetails.FirstOrDefaultAsync(x => x.RollNo == rollNo);
                _logger.LogInformation($"Received Student's Curriculam Details for roll no {rollNo}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return studentCurriculamDetails!;
        }        

        public async Task<List<StudentRecords>> GetStudentRecords()
        {
            List<StudentRecords> studentRecords = new List<StudentRecords>();

            try
            {
                studentRecords = await _studentService.StudentRecords.ToListAsync();
                _logger.LogInformation("Received Student's Details");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return studentRecords!;
        }

        public async Task<StudentRecords> GetStudentRecords(int rollNo)
        {
            StudentRecords studentRecords = new StudentRecords();

            try
            {
                studentRecords = await _studentService.StudentRecords.FirstOrDefaultAsync(x => x.RollNo == rollNo);
                _logger.LogInformation("Received Student's Details");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return studentRecords!;
        }
        public async Task<StudentPersonalDetails> AddStudent(StudentPersonalDetails studentPersonalDetails)
        {
            var studentRecord = new StudentRecords
            {
                Id = studentPersonalDetails.Id,
                RollNo = studentPersonalDetails.RollNo,
                Active = true,
                StudentName = studentPersonalDetails.Name
            };
            var studentCurriculamRecord = new StudentCurriculamDetails
            {
                Id = studentPersonalDetails.Id,
                RollNo = studentPersonalDetails.RollNo,
                Class = studentPersonalDetails.Class,
            };

            try
            {
                _studentService.StudentPersonalDetails.Add(studentPersonalDetails);
                _studentService.StudentRecords.Add(studentRecord);
                _studentService.StudentCurriculamDetails.Add(studentCurriculamRecord);
                await _studentService.SaveChangesAsync();
                _logger.LogInformation("Successfully added Student's Personal Details as well as Curriculam Details");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return studentPersonalDetails;
        }
        public Task<StudentPersonalDetails> RemoveStudentPersonalDetails(int rollNo)
        {
            throw new NotImplementedException();
        }
    }
}
