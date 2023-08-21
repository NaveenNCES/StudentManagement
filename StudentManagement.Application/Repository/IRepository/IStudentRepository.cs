using StudentManagement.Domain.DTO;

namespace StudentManagement.Application.Repository.IRepository
{
    public interface IStudentRepository
    {
        Task<StudentDetail> GetStudentDetailsAsync();
    }
}