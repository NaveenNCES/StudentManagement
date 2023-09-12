using System.Net;
using System.Net.Http.Json;
using AutoFixture;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using StudentManagement.Api.Models;
using StudentManagement.Api.RouteConstant;
using StudentManagement.Domain.Context;
using StudentManagement.IntegrationTest.Constant;
using StudentManagement.IntegrationTesting.HttpTests;
using Xunit;

namespace StudentManagement.IntegrationTesting.Controllers
{
    public class StudentControllerTest : IClassFixture<CustomWebApplicationFactory<Program>>
    {
        private readonly CustomWebApplicationFactory<Program> _appFactory;
        private readonly HttpClient _httpClient;
        private readonly Fixture _fixture;

        public StudentControllerTest(CustomWebApplicationFactory<Program> appFactory)
        {
            _appFactory = appFactory;
            _fixture = new Fixture();
            _httpClient = _appFactory.CreateClient(new WebApplicationFactoryClientOptions
            {
                AllowAutoRedirect = false
            });
        }

        [Fact]
        public async Task Should_Get_StudentDetails()
        {
            //Arrange
            var fixtureDBData = new FixtureDBData();
            fixtureDBData.InitializeDataBase(_appFactory);

            //Act
            var response = await _httpClient.GetAsync($"{TestConstant.Url}{ApiRouteConstant.Api}/{ApiRouteConstant.GetStudentDetails}");
            var result = await response.Content.ReadFromJsonAsync<List<StudentDetail>>();

            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task Should_Post_StudentDetails()
        {
            //Arrange
            var fixtureDBData = new FixtureDBData();
            fixtureDBData.InitializeDataBase(_appFactory);
            var studentDetail = _fixture.Build<StudentDetail>()
                .Without(x => x.Id)
                .Create();

            //Act
            var response = await _httpClient.PostAsJsonAsync($"{TestConstant.Url}{ApiRouteConstant.Api}/{ApiRouteConstant.PostStudentDetails}", studentDetail);

            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task Should_Post_StudentDetails_Will_Return500()
        {
            //Arrange
            var fixtureDBData = new FixtureDBData();
            fixtureDBData.InitializeDataBase(_appFactory);
            var studentDetail = _fixture.Create<StudentDetail>();

            //Act
            var response = await _httpClient.PostAsJsonAsync($"{TestConstant.Url}{ApiRouteConstant.Api}/{ApiRouteConstant.PostStudentDetails}", studentDetail);

            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.InternalServerError);
        }

        [Fact]
        public async Task Should_Get_SelectedStudentDetails_Will_StudentDetails()
        {
            //Arrange
            var fixtureDBData = new FixtureDBData();
            fixtureDBData.InitializeDataBase(_appFactory);
            var studentDetail = _fixture.Build<StudentDetail>()
                .With(x => x.RollNumber, 1713050)
                .With(x => x.DateOfBirth, "09/08/2000")
                .Create();

            //Act
            var response = await _httpClient.PostAsJsonAsync($"{TestConstant.Url}{ApiRouteConstant.Api}/{ApiRouteConstant.GetSelectedStudentDetail}", studentDetail);
            var result = await response.Content.ReadFromJsonAsync<StudentDetail>();

            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            result?.RollNumber.Should().Be(studentDetail.RollNumber);
            result?.DateOfBirth?.Trim().Should().Be(studentDetail.DateOfBirth);
        }
    }
}