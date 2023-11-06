using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentHelper.Admin.API.Models;
using StudentHelper.Admin.API.Repository.School;

namespace StudentHelper.Admin.API.Controllers
{
    [Route("api/[controller]/action")]
    [ApiController]
    public class SubjectController : ControllerBase
    {
        private readonly ISubjectRepository _subjectRepository;

        public SubjectController(ISubjectRepository subjectRepository)
        {
            _subjectRepository = subjectRepository;
        }

        [HttpGet]
        public IEnumerable<SubjectDto> GetSubjects()
        {
            return _subjectRepository.GetSubjects();
        }

        [HttpGet]
        public SubjectDto GetSubjectById(int subjectId)
        {
            return _subjectRepository.GetSubject(subjectId);
        }

        [HttpPost]
        public SubjectDto CreateUpdateSubject(SubjectDto subjectDto)
        {
            return _subjectRepository.CreateUpdateSubject(subjectDto);
        }

        [HttpDelete]
        public ActionResult DeleteSubjectById(int subjectId)
        {
            var isDeleted = _subjectRepository.RemoveSubject(subjectId);

            if (isDeleted)
                return Ok();
            else
                return NotFound();
        }
    }
}
