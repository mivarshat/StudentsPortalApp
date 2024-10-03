using Microsoft.AspNetCore.Mvc;
using StudentsPortalApp.Services;
using StudentsPortalApp.StudentModel;

namespace StudentsPortalApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentsController : Controller
    {
        private readonly IStudentService _studentService;
        public StudentsController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        // GET: api/students
        [HttpGet]
        public async Task<IActionResult> GetStudents()
        {
            var studentsRecords = await _studentService.GetStudentPersonalDetails();
            return Ok(studentsRecords);
        }

        // GET: api/students/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudentById(int id)
        {
            var studentsRecords = await _studentService.GetStudentPersonalDetailsById(id);
            return Ok(studentsRecords);
        }

        [HttpPost]
        public async Task<IActionResult> AddStudentPersonalDetails([FromBody] StudentPersonalDetails studentPersonalDetails)
        {
            var studentsRecords = await _studentService.AddStudent(studentPersonalDetails);
            return Ok(studentsRecords);
        }
    }
}
