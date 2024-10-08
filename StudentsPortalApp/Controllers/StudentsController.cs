using Microsoft.AspNetCore.Mvc;
using StudentsPortalApp.Services;
using StudentsPortalApp.StudentModel;

namespace StudentsPortalApp.Controllers
{   
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class StudentsController : Controller
    {
        private readonly IStudentService _studentService;
        private readonly ILogger<StudentsController> _logger;

        public StudentsController(IStudentService studentService, ILogger<StudentsController> logger)
        {
            _studentService = studentService;
            _logger = logger;
        }
        // GET: api/students
        [HttpGet]
        [Route("student")]
        [ApiVersion("1.0")]
        public async Task<IActionResult> GetStudentsRecord()
        {
            _logger.LogInformation("Accessing Student's Record Process started");
            var studentsRecords = await _studentService.GetStudentRecords();
            return Ok(studentsRecords);
        }

        // GET: api/students/5
        [HttpGet]
        [Route("student/{rollNo}")]
        [ApiVersion("1.0")]
        public async Task<IActionResult> GetStudentRecordByRollNo(int rollNo)
        {
            _logger.LogInformation($"Accessing Student's Record for roll no {rollNo} Process started");
            var studentsRecords = await _studentService.GetStudentRecords(rollNo);
            return Ok(studentsRecords);
        }
        // GET: api/students
        [HttpGet]
        [Route("student/personal")]
        [ApiVersion("1.0")]
        public async Task<IActionResult> GetStudentsPersonalDetails()
        {
            _logger.LogInformation("Accessing Student's record Process started");
            var studentsRecords = await _studentService.GetStudentPersonalDetails();
            return Ok(studentsRecords);
        }

        // GET: api/students/5
        [HttpGet]
        [Route("student/personal/{rollNo}")]
        [ApiVersion("1.0")]
        public async Task<IActionResult> GetStudentPersonalDetailsByRollNo(int rollNo)
        {
            _logger.LogInformation($"Accessing Student's record for roll no {rollNo} Process started");
            var studentsRecords = await _studentService.GetStudentPersonalDetails(rollNo);
            return Ok(studentsRecords);
        }

        // GET: api/students
        [HttpGet]
        [Route("student/curriculam")]
        [ApiVersion("1.0")]
        public async Task<IActionResult> GetStudentsCurriculamDetails()
        {
            _logger.LogInformation("Accessing Student's Curriculam Details Process started");
            var studentsRecords = await _studentService.GetStudentCurriculamDetails();
            return Ok(studentsRecords);
        }

        // GET: api/students/5
        [HttpGet]
        [Route("student/curriculam/{rollNo}")]
        [ApiVersion("1.0")]
        public async Task<IActionResult> GetStudentCurriculamDetailsById(int rollNo)
        {
            _logger.LogInformation($"Accessing Student's Curriculam Details for roll no {rollNo} Process started");
            var studentsRecords = await _studentService.GetStudentCurriculamDetails(rollNo);
            return Ok(studentsRecords);
        }

        [HttpPost]
        [ApiVersion("1.0")]
        public async Task<IActionResult> AddStudentPersonalDetails([FromBody] StudentPersonalDetails studentPersonalDetails)
        {
            _logger.LogInformation("Adding Student's record Process started");
            var studentsRecords = await _studentService.AddStudent(studentPersonalDetails);
            return Ok(studentsRecords);
        }
    }
}
