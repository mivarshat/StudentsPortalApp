using AutoFixture;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NSubstitute;
using StudentsPortalApp.EFContext;
using StudentsPortalApp.Services;
using StudentsPortalApp.StudentModel;

namespace UnitTests.Services
{
    public class StudentServiceTests
    {
        private readonly IFixture fixture;
        private readonly DbContextOptions<StudentInformationlDBContext> dbContextOptions;
        private readonly StudentInformationlDBContext _studentDbContext;
        private readonly StudentRecords studentRecords;
        private readonly StudentPersonalDetails personalDetails;
        private readonly StudentCurriculamDetails curriculamDetails;
        private readonly ILogger<StudentService> _logger;
        private readonly StudentService _sut;

        public StudentServiceTests()
        {
            fixture = new Fixture();
            dbContextOptions = new DbContextOptionsBuilder<StudentInformationlDBContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;
            _studentDbContext = new StudentInformationlDBContext(dbContextOptions);

            //Arrange Data
            studentRecords = fixture.Create<StudentRecords>();
            personalDetails = fixture.Create<StudentPersonalDetails>();
            curriculamDetails = fixture.Create<StudentCurriculamDetails>();
            _studentDbContext.StudentRecords.Add(studentRecords);
            _studentDbContext.StudentPersonalDetails.Add(personalDetails);
            _studentDbContext.StudentCurriculamDetails.Add(curriculamDetails);
            _studentDbContext.SaveChanges();

            _logger = Substitute.For<ILogger<StudentService>>();
            _sut = new StudentService(_studentDbContext, _logger);
        }

        [Fact]
        public async void GetStudentPersonalDetails_Valid_ValidResponse()
        {
            //Act
            var result = await _sut.GetStudentPersonalDetails();

            //Assert
            Assert.NotNull(result);
        }

        [Fact]
        public async void GetStudentPersonalDetails_ValidRollNo_ValidResponse()
        {
            //Act
            var result = await _sut.GetStudentPersonalDetails(personalDetails.RollNo);

            //Assert
            Assert.NotNull(result.Item2);
        }

        [Fact]
        public async void GetStudentCurriculamDetails_Valid_ValidResponse()
        {
            //Act
            var result = await _sut.GetStudentCurriculamDetails();

            //Assert
            Assert.NotNull(result);
        }

        [Fact]
        public async void GetStudentCurriculamDetailsByRollNo_Valid_ValidResponse()
        {
            //Act
            var result = await _sut.GetStudentCurriculamDetails(curriculamDetails.RollNo);

            //Assert
            Assert.NotNull(result.Item2);
        }
    }
}
