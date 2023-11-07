using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentHelper.Teacher.API.Models;
using StudentHelper.Teacher.API.Repository;

namespace StudentHelper.Teacher.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentRepository _studentRepository;

        public StudentController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        [HttpGet]
        public IEnumerable<UserDto> GetUserByClass(int classId)
        {
            return _studentRepository.GetClassStudents(classId);
        }
    }
}
