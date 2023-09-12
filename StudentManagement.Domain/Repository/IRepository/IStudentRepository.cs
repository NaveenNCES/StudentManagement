using StudentManagement.Api.Models;

namespace StudentManagement.Application.Repository.IRepository
{
    public interface IStudentRepository
    {
        Task<IReadOnlyList<StudentDetail>> GetStudentDetailsAsync();
        Task SetStudentDetailsAsync(StudentDetail studentDetail);
        Task<bool> DeleteStudentDetailAsync(int id);
        Task<StudentDetail?> GetSelectedStudentDetailAsync(StudentDetail studentDetail);
    }
}