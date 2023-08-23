using Microsoft.AspNetCore.Mvc;
using StudentManagement.Api.RouteConstant;
using StudentManagement.Application.Repository.IRepository;

namespace StudentManagement.Api.Controllers
{
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentRepository _studentRepository;

        public StudentController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        [HttpGet($"{ApiRouteConstant.Api}/{ApiRouteConstant.GetStudentDetails}")]
        public async Task<IActionResult> GetStudentDetailsAsync()
        {
            try
            {
                var studentDetails = await _studentRepository.GetStudentDetailsAsync();

                if (studentDetails == null)
                {
                    return BadRequest();
                }

                return Ok(studentDetails);
            }
            catch (Exception exçeption)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { exçeption.Message, Type = exçeption.GetType().ToString() });
            }
        }
    }
}
