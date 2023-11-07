using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentHelper.Teacher.API.Models;
using StudentHelper.Teacher.API.Repository;

namespace StudentHelper.Teacher.API.Controllers
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
        public IEnumerable<SubjectDto> GetTeacherSubject(int teacherId)
        {
            return _subjectRepository.GetTeacherSubjects(teacherId);
        }

        [HttpGet]

        public SubjectDto GetSubject(int subjectId)
        {
            return _subjectRepository.GetSubject(subjectId);
        }

    }
}
