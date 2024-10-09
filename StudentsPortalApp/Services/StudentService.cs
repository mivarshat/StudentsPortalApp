using Microsoft.EntityFrameworkCore;
using StudentsPortalApp.EFContext;
using StudentsPortalApp.StudentModel;

namespace StudentsPortalApp.Services
{
    public class StudentService : IStudentService
    {
        private readonly StudentInformationlDBContext _studentDbContext;
        private readonly ILogger<StudentService> _logger;

        public StudentService(StudentInformationlDBContext studentDbContext, ILogger<StudentService> logger)
        {
            _studentDbContext = studentDbContext;
            _logger = logger;
        }

        public async Task<List<StudentPersonalDetails>> GetStudentPersonalDetails()
        {
            List<StudentPersonalDetails> studentsRecords = new List<StudentPersonalDetails>();

            try
            {
                studentsRecords = await _studentDbContext.StudentPersonalDetails.ToListAsync();
                _logger.LogInformation("Received Student's Personal Details");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return studentsRecords!;
        }

        public async Task<(int, StudentPersonalDetails)> GetStudentPersonalDetails(int rollNo)
        {
            StudentPersonalDetails studentPersonalDetails = new StudentPersonalDetails();
            try
            {
                studentPersonalDetails = await _studentDbContext.StudentPersonalDetails.FirstOrDefaultAsync(x => x.RollNo == rollNo);
                _logger.LogInformation($"Received Student's Personal Details for roll no {studentPersonalDetails!.RollNo}");
               return(StatusCodes.Status200OK, studentPersonalDetails);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return (StatusCodes.Status404NotFound, studentPersonalDetails!);
        }

        public async Task<List<StudentCurriculamDetails>> GetStudentCurriculamDetails()
        {
            List<StudentCurriculamDetails> studentCurriculamDetails = new List<StudentCurriculamDetails>();

            try
            {
                studentCurriculamDetails = await _studentDbContext.StudentCurriculamDetails.ToListAsync();
                _logger.LogInformation("Received Student's Curriculam Details");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return studentCurriculamDetails!;
        }

        public async Task<(int,StudentCurriculamDetails)> GetStudentCurriculamDetails(int rollNo)
        {
            StudentCurriculamDetails studentCurriculamDetails = new StudentCurriculamDetails();

            try
            {
                studentCurriculamDetails = await _studentDbContext.StudentCurriculamDetails.FirstOrDefaultAsync(x => x.RollNo == rollNo);
                _logger.LogInformation($"Received Student's Curriculam Details for roll no {rollNo}");
                return (StatusCodes.Status200OK, studentCurriculamDetails);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return (StatusCodes.Status404NotFound, studentCurriculamDetails);
        }

        public async Task<List<StudentRecords>> GetStudentRecords(bool active)
        {
            List<StudentRecords> studentRecords = new List<StudentRecords>();

            try
            {
                studentRecords = await _studentDbContext.StudentRecords.Where(x => x.Active == active).ToListAsync();
                _logger.LogInformation("Received Student's Details");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return studentRecords!;
        }

        public async Task<(int, StudentRecords)> GetStudentRecords(int rollNo)
        {
            StudentRecords studentRecords = new StudentRecords();

            try
            {
                studentRecords = await _studentDbContext.StudentRecords.FirstOrDefaultAsync(x => x.RollNo == rollNo);
                _logger.LogInformation("Received Student's Details");
                return(StatusCodes.Status200OK, studentRecords!);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return (StatusCodes.Status404NotFound, studentRecords!);
        }
        public async Task<(int, StudentPersonalDetails)> AddStudent(StudentPersonalDetails studentPersonalDetails)
        {
            var result = await GetStudentRecords(studentPersonalDetails.RollNo);
            if (result.Item2 == null)
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
                    _studentDbContext.StudentPersonalDetails.Add(studentPersonalDetails);
                    _studentDbContext.StudentRecords.Add(studentRecord);
                    _studentDbContext.StudentCurriculamDetails.Add(studentCurriculamRecord);
                    await _studentDbContext.SaveChangesAsync();
                    _logger.LogInformation("Successfully added Student's Personal Details as well as Curriculam Details");
                    return (StatusCodes.Status201Created, studentPersonalDetails);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex.Message);
                }
            }
            else
            {
                _logger.LogInformation($"Student with Roll No {studentPersonalDetails.RollNo} already exists");
            }
            return (StatusCodes.Status404NotFound, studentPersonalDetails);
        }
        public async Task<(int, string)> ActivateDeactivateStudent(int rollNo, bool active)
        {
            try
            {
                var studentRecord = await _studentDbContext.StudentRecords.FirstOrDefaultAsync(x => x.RollNo == rollNo);
                if (studentRecord != null)
                {
                    studentRecord.Active = active;
                    await _studentDbContext.SaveChangesAsync();
                    _logger.LogInformation($"Successfully updated Student's for roll no {rollNo}");
                    return (StatusCodes.Status204NoContent, $"Successfully updated Student of roll no {rollNo}");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return (StatusCodes.Status404NotFound, $"Updation of Student of roll no {rollNo} failed");
        }

        public async Task<(int, string)> EditStudentPersonalDetails(int rollNo, StudentPersonalDetails personalDetails)
        {
            try
            {
                var existingPersonalDetails = await _studentDbContext.StudentPersonalDetails.FirstOrDefaultAsync(x => x.RollNo == rollNo);
                if (existingPersonalDetails != null)
                {
                    // existingPersonalDetails.RollNo = personalDetails.RollNo;
                    existingPersonalDetails.Name = personalDetails.Name;
                    existingPersonalDetails.Class = personalDetails.Class;
                    existingPersonalDetails.Email = personalDetails.Email;
                    existingPersonalDetails.Address = personalDetails.Address;
                    existingPersonalDetails.Phone = personalDetails.Phone;
                    existingPersonalDetails.Division = personalDetails.Division;

                    await _studentDbContext.SaveChangesAsync();
                    _logger.LogInformation($"Successfully updated Student's for roll no {rollNo}");
                    return (StatusCodes.Status204NoContent, $"Successfully updated Student of roll no {rollNo}");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return (StatusCodes.Status404NotFound, $"Updation of Student of roll no {rollNo} failed");
        }

        public async Task<(int, string)> EditStudentCurriculamDetails(int rollNo, StudentCurriculamDetails curriculamDetails)
        {
            try
            {
                var existingCurriculamDetails = await _studentDbContext.StudentCurriculamDetails.FirstOrDefaultAsync(x => x.RollNo == rollNo);
                if (existingCurriculamDetails != null)
                {
                    existingCurriculamDetails.SSTMarks = curriculamDetails.SSTMarks;
                    existingCurriculamDetails.MarathiMarks = curriculamDetails.MarathiMarks;
                    existingCurriculamDetails.MathsMarks = curriculamDetails.MathsMarks;
                    existingCurriculamDetails.HindiMarks = curriculamDetails.HindiMarks;
                    existingCurriculamDetails.ComputerMarks= curriculamDetails.ComputerMarks;
                    existingCurriculamDetails.ScienceMarks = curriculamDetails.ScienceMarks;
                    existingCurriculamDetails.EnglishMarks = curriculamDetails.EnglishMarks;
                    existingCurriculamDetails.Class= curriculamDetails.Class;

                    await _studentDbContext.SaveChangesAsync();
                    _logger.LogInformation($"Successfully updated Student's for roll no {rollNo}");
                    return (StatusCodes.Status204NoContent, $"Successfully updated Student of roll no {rollNo}");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return (StatusCodes.Status404NotFound, $"Updation of Student of roll no {rollNo} failed");
        }
    }
}
