using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentHelper.Student.API.Models.School;
using StudentHelper.Student.API.Repository;

namespace StudentHelper.Student.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MarkController : ControllerBase
    {
        private readonly IMarkRepository _markRepository;

        public MarkController(IMarkRepository markRepository)
        {
            _markRepository = markRepository;
        }

        [HttpGet]
        public MarkDto GetMark(int markId)
        {
            return _markRepository.GetMark(markId);
        }

        [HttpGet]
        public IEnumerable<MarkDto> GetStudentMarks(int studentId) 
        { 
        return _markRepository.GetStudentsMark(studentId);
        }

        [HttpGet]
        public IEnumerable<MarkDto> GetStudentSubjectMark(int studentId, int subjectId)
        {
            return _markRepository.GetStudentSubjectMark(studentId, subjectId);
        }

    }
}
