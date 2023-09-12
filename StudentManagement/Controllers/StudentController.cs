using Microsoft.AspNetCore.Mvc;
using StudentManagement.Api.Models;
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

                return studentDetails == null ? BadRequest() : Ok(studentDetails);
            }
            catch (Exception exçeption)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { exçeption.Message, Type = exçeption.GetType().ToString() });
            }
        }

        [HttpPost($"{ApiRouteConstant.Api}/{ApiRouteConstant.GetSelectedStudentDetail}")]
        public async Task<IActionResult> GetSelectedStudentDetailsAsync(StudentDetail studentDetail)
        {
            try
            {
                var selectedStudentDetail = await _studentRepository.GetSelectedStudentDetailAsync(studentDetail);

                return selectedStudentDetail == null ? BadRequest() : Ok(selectedStudentDetail);
            }
            catch (Exception exçeption)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { exçeption.Message, Type = exçeption.GetType().ToString() });
            }
        }

        [HttpPost($"{ApiRouteConstant.Api}/{ApiRouteConstant.PostStudentDetails}")]
        public async Task<IActionResult> SetStudentDetailsAsync(StudentDetail studentDetail)
        {
            try
            {
                await _studentRepository.SetStudentDetailsAsync(studentDetail);

                return Ok();
            }
            catch (Exception exçeption)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { exçeption.Message, Type = exçeption.GetType().ToString() });
            }
        }

        [HttpDelete($"{ApiRouteConstant.Api}/{ApiRouteConstant.DeleteStudentDetails}"+ "/{studentId}")]
        public async Task<IActionResult> DeleteStudentDetailsAsync(int studentId)
        {
            try
            {
                await _studentRepository.DeleteStudentDetailAsync(studentId);

                return Ok();
            }
            catch (Exception exçeption)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { exçeption.Message, Type = exçeption.GetType().ToString() });
            }
        }

    }
}
