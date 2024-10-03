using Microsoft.EntityFrameworkCore;
using StudentsPortalApp.EFContext;
using StudentsPortalApp.StudentModel;

namespace StudentsPortalApp.Services
{
    public class StudentService : IStudentService
    {
        private readonly StudentInformationlDBContext _studentService;

        public StudentService(StudentInformationlDBContext studentService)
        {
            _studentService = studentService;
        }

        public async Task<StudentPersonalDetails> AddStudent(StudentPersonalDetails studentPersonalDetails)
        {
            var studentRecords = new StudentRecords
            {
                Id = studentPersonalDetails.Id,
                RollNo = studentPersonalDetails.RollNo,
                Active = true,
                StudentName = studentPersonalDetails.Name
            };
            var studentCurriculamRecords = new StudentCurriculamDetails
            {
                Id = studentPersonalDetails.Id,
                RollNo = studentPersonalDetails.RollNo,
                Class = studentPersonalDetails.Class,
                MathsMarks = 0, EnglishMarks = 0, HindiMarks = 0, ScienceMarks = 0,
                SSTMarks = 0, ComputerMarks = 0, MarathiMarks = 0
            };          

            try
            {
                _studentService.StudentPersonalDetails.Add(studentPersonalDetails);
                _studentService.StudentRecords.Add(studentRecords);
                _studentService.StudentCurriculamDetails.Add(studentCurriculamRecords);
                await _studentService.SaveChangesAsync();
            }
            catch (Exception ex)
            {
            }
            return studentPersonalDetails;
        }

        public async Task<List<StudentCurriculamDetails>> GetStudentCurriculamDetails()
        {
            List<StudentCurriculamDetails> studentCurriculamDetails = null!;

            try
            {
                studentCurriculamDetails = await _studentService.StudentCurriculamDetails.ToListAsync();

                if (studentCurriculamDetails == null)
                {
                    return new List<StudentCurriculamDetails>();
                }
            }
            catch (Exception ex)
            {
            }


            return studentCurriculamDetails!;
        }

        public async Task<StudentCurriculamDetails> GetStudentCurriculamDetails(int rollNo)
        {
            StudentCurriculamDetails studentCurriculamDetails = null!;

            try
            {
                studentCurriculamDetails = await _studentService.StudentCurriculamDetails.FindAsync(rollNo);

                if (studentCurriculamDetails == null)
                {
                    return new StudentCurriculamDetails();
                }
            }
            catch (Exception ex)
            {

            }
            return studentCurriculamDetails;
        }

        public async Task<List<StudentPersonalDetails>> GetStudentPersonalDetails()
        {
            List<StudentPersonalDetails> studentsRecords = null!;

            try
            {
                studentsRecords = await _studentService.StudentPersonalDetails.ToListAsync();

                if (studentsRecords == null)
                {
                    return new List<StudentPersonalDetails>();
                }
            }
            catch (Exception ex)
            {
               
            }


            return studentsRecords!;
        }

        public async Task<StudentPersonalDetails> GetStudentPersonalDetailsById(int id)
        {
            StudentPersonalDetails studentPersonalDetail = new StudentPersonalDetails();
            try
            {
                studentPersonalDetail = await _studentService.StudentPersonalDetails.FindAsync(id);

            }
            catch (Exception ex)
            {
            }
            return studentPersonalDetail!;
        }

        public async Task<List<StudentRecords>> GetStudentRecords()
        {
            List<StudentRecords> studentCurriculamDetails = null!;

            try
            {
                studentCurriculamDetails = await _studentService.StudentRecords.ToListAsync();

                if (studentCurriculamDetails == null)
                {
                    return new List<StudentRecords>();
                }
            }
            catch (Exception ex)
            {

            }

            return studentCurriculamDetails!;
        }

        public async Task<StudentRecords> GetStudentRecords(int rollNo)
        {
            StudentRecords studentCurriculamDetails = null!;

            try
            {
                studentCurriculamDetails = await _studentService.StudentRecords.FindAsync(rollNo);

                if (studentCurriculamDetails == null)
                {
                    return new StudentRecords();
                }
            }
            catch (Exception ex)
            {

            }
            return studentCurriculamDetails;
        }

        public Task<StudentPersonalDetails> RemoveStudentPersonalDetails(int rollNo)
        {
            throw new NotImplementedException();
        }
    }
}
