using AutoFixture;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NSubstitute;
using StudentsPortalApp.Controllers;
using StudentsPortalApp.Services;
using StudentsPortalApp.StudentModel;

namespace UnitTests.Controllers
{
    public class StudentsControllerTests
    {
        private readonly IFixture fixture;
        private readonly ILogger<StudentsController> logger;
        private readonly IStudentService studentService;
        private readonly StudentsController _sut;

        public StudentsControllerTests()
        {
            fixture = new Fixture();
            logger = Substitute.For<ILogger<StudentsController>>();
            studentService = Substitute.For<IStudentService>();
            _sut = Substitute.For<StudentsController>(studentService, logger);
        }

        [Theory]
        [InlineData(1)]
        public async Task GetStudentRecordByRollNo_ValidRollNo_ValidResponse(int rollNo)
        {
            //Arrange
            StudentRecords studentRecords = fixture.Create<StudentRecords>();
            var response = fixture.Build<(int, StudentRecords)>()
                                .With(x => x.Item1, 200)
                                .With(x => x.Item2, studentRecords)
                                .Create();

            studentService.GetStudentRecords(rollNo).Returns(Task.FromResult(response));

            //Act
            var result = await _sut.GetStudentRecordByRollNo(rollNo);

            //Assert
            ObjectResult objectResult = (ObjectResult)result!;
            Assert.NotNull(result);
        }
    }
}
