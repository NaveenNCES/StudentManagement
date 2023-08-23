using Microsoft.EntityFrameworkCore;
using StudentManagement.Api.Models;
using StudentManagement.Application.Repository.IRepository;
using StudentManagement.Domain.Context;

namespace StudentManagement.Domain.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly StudentDatabaseContext _studentDatabaseContext;

        public StudentRepository(StudentDatabaseContext studentDatabaseContext) 
        {
            _studentDatabaseContext = studentDatabaseContext;
        }

        public async Task<IReadOnlyList<StudentDetail>> GetStudentDetailsAsync()
        {
            return await _studentDatabaseContext.StudentDetails.ToListAsync();
        }
    }
}