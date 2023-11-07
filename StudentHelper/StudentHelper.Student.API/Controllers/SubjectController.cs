using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentHelper.Student.API.Models;
using StudentHelper.Student.API.Repository;

namespace StudentHelper.Student.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SubjectController : ControllerBase
    {
        private readonly ISubjectRepository _subjectRepository;

        public SubjectController(ISubjectRepository subjectRepository)
        {
            _subjectRepository = subjectRepository;
        }

        [HttpGet]

        public IEnumerable<SubjectDto> GetStudentSubjects(int userId)
        {
            return _subjectRepository.GetStudentSubjects(userId);
        }

        [HttpGet]
        public SubjectDto GetSubject(int subjectId)
        {
            return _subjectRepository.GetSubject(subjectId);
        }
    }
}
