using AutoFixture;
using Microsoft.Extensions.DependencyInjection;
using StudentManagement.Api.Models;
using StudentManagement.Domain.Context;

namespace StudentManagement.IntegrationTesting.HttpTests
{
    public class FixtureDBData
    {
        private readonly Fixture _fixture;

        public FixtureDBData()
        {
            _fixture = new Fixture();
        }

        public List<StudentDetail> FetchStudentDetails()
        {
            return _fixture.Build<StudentDetail>()
                .Without(x => x.Id)
                .CreateMany()
                .ToList();
        }

        public async void InitializeDataBase(CustomWebApplicationFactory<Program> factory)
        {
            using var scope = factory.Services.CreateAsyncScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<StudentDatabaseContext>();

            var studentDetails = FetchStudentDetails();
            await dbContext.StudentDetails.AddRangeAsync(studentDetails);
            await dbContext.SaveChangesAsync();
        }
    }
}
