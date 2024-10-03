using StudentsPortalApp.StudentModel;

namespace StudentsPortalApp.Services
{
    public interface IStudentService
    {
        Task<List<StudentPersonalDetails>> GetStudentPersonalDetails();
        Task<List<StudentRecords>> GetStudentRecords();
        Task<List<StudentCurriculamDetails>> GetStudentCurriculamDetails();
        Task<StudentRecords> GetStudentRecords(int rollNo);
        Task<StudentCurriculamDetails> GetStudentCurriculamDetails(int rollNo);
        Task<StudentPersonalDetails> GetStudentPersonalDetailsById(int id);
        Task<StudentPersonalDetails> AddStudent(StudentPersonalDetails studentPersonalDetails);
        Task<StudentPersonalDetails> RemoveStudentPersonalDetails(int rollNo);
    }
}
