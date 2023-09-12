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

        public async Task SetStudentDetailsAsync(StudentDetail studentDetail)
        {
            await _studentDatabaseContext.AddAsync(studentDetail);
            await _studentDatabaseContext.SaveChangesAsync();
        }

        public async Task<bool> DeleteStudentDetailAsync(int id)
        {

            var selectedStudent = await _studentDatabaseContext.StudentDetails.FirstOrDefaultAsync(x => x.Id == id);

            if (selectedStudent == null)
            {
                return false;
            }

            _studentDatabaseContext.StudentDetails.Remove(selectedStudent);
            await _studentDatabaseContext.SaveChangesAsync();

            return true;
        }

        public async Task<StudentDetail?> GetSelectedStudentDetailAsync(StudentDetail studentDetail)
        {
            var selectedStudent = await _studentDatabaseContext.StudentDetails.FirstOrDefaultAsync(x => x.RollNumber == studentDetail.RollNumber && x.DateOfBirth == studentDetail.DateOfBirth);
            return selectedStudent == null ? null : selectedStudent;
        }
    }
}