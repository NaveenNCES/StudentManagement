using AutoFixture;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using StudentManagement.Api.Models;
using StudentManagement.Domain.Context;
using StudentManagement.Domain.Repository;
using Xunit;

namespace StudentManagement.Test.Repositories
{
    public class StudentRepositoryTest
    {
        private readonly StudentDatabaseContext _studentDatabaseContext;
        private readonly Fixture _fixture;

        public StudentRepositoryTest()
        {
            _fixture = new Fixture();

            DbContextOptionsBuilder dboptions = new DbContextOptionsBuilder<StudentDatabaseContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString());
            _studentDatabaseContext = new StudentDatabaseContext(dboptions.Options);
        }

        [Fact]
        public void Create_Service()
        {
            //Arrange

            //Act 

            //Assert
            _studentDatabaseContext.Should().NotBeNull();
        }

        [Fact]
        public async void Should_Return_StudentDetails_When_StudentDatabaseContext_Is_Called()
        {
            //Arrange
            var studentDetails = _fixture.CreateMany<StudentDetail>();
            await _studentDatabaseContext.AddRangeAsync(studentDetails);
            await _studentDatabaseContext.SaveChangesAsync();
            var studentRepository = new StudentRepository(_studentDatabaseContext);

            //Act
            var result = await studentRepository.GetStudentDetailsAsync();

            //Assert
            result.Should().BeEquivalentTo(studentDetails);
        }
    }
}