using Azure;
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
        public async Task<IActionResult> GetStudentsRecord(bool active)
        {
            _logger.LogInformation("Accessing Student's Record Process started");
            var studentsRecords = await _studentService.GetStudentRecords(active);
            return Ok(studentsRecords);
        }

        // GET: api/students/5
        [HttpGet]
        [Route("student/{rollNo}")]
        [ApiVersion("1.0")]
        public async Task<IActionResult> GetStudentRecordByRollNo(int rollNo)
        {
            _logger.LogInformation($"Accessing Student's Record for roll no {rollNo} Process started");
            var (statusCode, result) = await _studentService.GetStudentRecords(rollNo);
            if (statusCode == 200)
            {
                return Ok(result);
            }
            return NotFound("Student not found");
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
            var (statusCode, result) = await _studentService.GetStudentPersonalDetails(rollNo);
            if (statusCode == 200)
            {
                return Ok(result);
            }
            return NotFound("Student not found");
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
            var (statusCode, result) = await _studentService.GetStudentCurriculamDetails(rollNo);
            if (statusCode == 200)
            {
                return Ok(result);
            }
            return NotFound("Student not found");
        }

        [HttpPost]
        [ApiVersion("1.0")]
        public async Task<ActionResult<string>> AddStudentPersonalDetails([FromBody] StudentPersonalDetails studentPersonalDetails)
        {
            _logger.LogInformation("Adding Student's record Process started");
            var response = await _studentService.AddStudent(studentPersonalDetails);
            if(response.Item1 == 201)
            {
                return Ok("Student Added Successfully");
            }
            return BadRequest("Failed adding student");
        }

        [HttpPatch]
        [Route("student/{rollNo}")]
        [ApiVersion("1.0")]
        public async Task<ActionResult<(int, string)>> ActivateDeactivateStudent(int rollNo,bool active)
        {
            _logger.LogInformation("Deactivating Student's record Process started");
            var (statusCode, result) = await _studentService.ActivateDeactivateStudent(rollNo,active);
            if (statusCode == 204)
            {
                return Ok(result);
            }
            return NotFound(result);
        }

        [HttpPatch]
        [Route("student/personal/{rollNo}")]
        [ApiVersion("1.0")]
        public async Task<ActionResult<(int, string)>> EditStudentPersonalDetails(int rollNo, StudentPersonalDetails personalDetails)
        {
            _logger.LogInformation("Editing Student's record Process started");
            var (statusCode, result) = await _studentService.EditStudentPersonalDetails(rollNo, personalDetails);
            if (statusCode == 204)
            {
                return Ok(result);
            }
            return NotFound(result);
        }

        [HttpPatch]
        [Route("student/curriculam/{rollNo}")]
        [ApiVersion("1.0")]
        public async Task<ActionResult<(int, string)>> EditStudentcurriculamDetails(int rollNo, StudentCurriculamDetails curriculamDetails)
        {
            _logger.LogInformation("Editing Student's record Process started");
            var (statusCode, result) = await _studentService.EditStudentCurriculamDetails(rollNo, curriculamDetails);
            if (statusCode == 204)
            {
                return Ok(result);
            }
            return NotFound(result);
        }
    }
}
