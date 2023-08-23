using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using StudentManagement.Application.Repository.IRepository;
using StudentManagement.Domain.Constant;
using StudentManagement.Domain.Context;
using StudentManagement.Domain.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString(AppConstant.BloggingDatabase);
builder.Services.AddDbContext<StudentDatabaseContext>(optionsBuilder => optionsBuilder.UseSqlServer(connectionString));

builder.Services.AddScoped<IStudentRepository, StudentRepository>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthorization();

app.MapControllers();

app.Run();