using Microsoft.AspNetCore.Mvc;
using StudentManagement.Api.RouteConstant;

namespace StudentManagement.Api.Controllers
{
    [ApiController]
    public class StudentController : ControllerBase
    {

        [HttpGet($"{ApiRouteConstant.Api}/{ApiRouteConstant.GetStudentDetails}")]
        public async Task<IActionResult> GetStudentDetailsAsync()
        {
            throw new NotImplementedException();
        }
    }
}
