using Microsoft.AspNetCore.Mvc;
using StudentHelper.Teacher.API.Models;
using StudentHelper.Teacher.API.Repository;

namespace StudentHelper.Teacher.API.Controllers
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
        public MarkDto GetMarkById(int markId)
        {
            return _markRepository.GetMark(markId);
        }

        [HttpGet]
        public IEnumerable<MarkDto> GetSubjectMarks(int subjectId)
        {
            return _markRepository.GetubjectMarks(subjectId);
        }

        [HttpPost]
        public MarkDto CreateUpdateMark(MarkDto markDto)
        {
            return _markRepository.CreateUpdateMark(markDto);
        }

        [HttpDelete]
        public ActionResult DeleteMark(int markId)
        {
            var isDelete = _markRepository.DeleteMark(markId);

            if (isDelete)
                return Ok();
            else
                return NotFound();
        }
    }
}
