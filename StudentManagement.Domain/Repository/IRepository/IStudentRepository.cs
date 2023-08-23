using StudentManagement.Api.Models;

namespace StudentManagement.Application.Repository.IRepository
{
    public interface IStudentRepository
    {
        Task<IReadOnlyList<StudentDetail>> GetStudentDetailsAsync();
    }
}