using StudentsPortalApp.StudentModel;

namespace StudentsPortalApp.Services
{
    public interface IStudentService
    {
        Task<List<StudentRecords>> GetStudentRecords(bool active);
        Task<(int, StudentRecords)> GetStudentRecords(int rollNo);
        Task<List<StudentPersonalDetails>> GetStudentPersonalDetails();
        Task<(int, StudentPersonalDetails)> GetStudentPersonalDetails(int rollNo);
        Task<List<StudentCurriculamDetails>> GetStudentCurriculamDetails();
        Task<(int, StudentCurriculamDetails)> GetStudentCurriculamDetails(int rollNo);
        Task<(int, StudentPersonalDetails)> AddStudent(StudentPersonalDetails studentPersonalDetails);
        Task<(int, string)> ActivateDeactivateStudent(int rollNo,bool active);
        Task<(int, string)> EditStudentPersonalDetails(int rollNo, StudentPersonalDetails personalDetails);
        Task<(int, string)> EditStudentCurriculamDetails(int rollNo, StudentCurriculamDetails curriculamDetails);
    }
}
