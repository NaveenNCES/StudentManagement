using AutoFixture;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using StudentManagement.Api.Controllers;
using StudentManagement.Api.Models;
using StudentManagement.Application.Repository.IRepository;
using Xunit;

namespace StudentManagement.Test.Controllers
{
    public class StudentControllerTest
    {
        private readonly MockRepository _mockRepository;
        public readonly StudentController _studentController;
        private readonly Mock<IStudentRepository> _studentRepository;
        private readonly Fixture _fixture;

        public StudentControllerTest()
        {
            _fixture = new Fixture();
            _mockRepository = new MockRepository(MockBehavior.Strict);

            _studentRepository= _mockRepository.Create<IStudentRepository>();
            _studentController = new StudentController(_studentRepository.Object);
        }

        [Fact]
        public void Create_Controller()
        {
            //Arrange

            //Act

            //Assert
            _studentController.Should().NotBeNull();

            _mockRepository.VerifyAll();
            _mockRepository.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task Should_Get_StudentDetails_And_200OK_When_StudentRepository_Iscalled()
        {
            //Arrange 
            var studentDetails = _fixture.CreateMany<StudentDetail>()
                .ToList();
            _studentRepository.Setup(x => x.GetStudentDetailsAsync()).ReturnsAsync(studentDetails);

            //Act
            var result = await _studentController.GetStudentDetailsAsync() as OkObjectResult;

            //Assert
            result.StatusCode.Should().Be(StatusCodes.Status200OK);
            result.Value.Should().BeEquivalentTo(studentDetails);
        }

        [Fact]
        public async Task Should_Get_Null_And_BadRequest_When_StudentRepository_Iscalled()
        {
            //Arrange 
            _studentRepository.Setup(x => x.GetStudentDetailsAsync()).ReturnsAsync(() => null);

            //Act
            var result = await _studentController.GetStudentDetailsAsync() as BadRequestResult;

            //Assert
            result.StatusCode.Should().Be(StatusCodes.Status400BadRequest);
        }

        [Fact]
        public async Task Should_Get_Exception_When_StudentRepository_Iscalled()
        {
            //Arrange 
            var exception = _fixture.Create<Exception>();
            _studentRepository.Setup(x => x.GetStudentDetailsAsync()).ThrowsAsync(exception);

            //Act
            var result = await _studentController.GetStudentDetailsAsync() as ObjectResult;

            //Assert
            result.StatusCode.Should().Be(StatusCodes.Status500InternalServerError);
        }
    }
}
