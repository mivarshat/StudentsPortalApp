using StudentsPortalApp.StudentModel;

namespace StudentsPortalApp.Services
{
    public interface IStudentService
    {
        Task<List<StudentRecords>> GetStudentRecords();
        Task<StudentRecords> GetStudentRecords(int rollNo);
        Task<List<StudentPersonalDetails>> GetStudentPersonalDetails();
        Task<StudentPersonalDetails> GetStudentPersonalDetails(int rollNo);
        Task<List<StudentCurriculamDetails>> GetStudentCurriculamDetails();
        Task<StudentCurriculamDetails> GetStudentCurriculamDetails(int rollNo);
        Task<StudentPersonalDetails> AddStudent(StudentPersonalDetails studentPersonalDetails);
        Task<StudentPersonalDetails> RemoveStudentPersonalDetails(int rollNo);
    }
}
