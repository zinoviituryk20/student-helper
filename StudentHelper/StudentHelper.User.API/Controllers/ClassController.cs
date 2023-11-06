using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentHelper.Admin.API.Models;
using StudentHelper.Admin.API.Repository;

namespace StudentHelper.Admin.API.Controllers
{
    [Route("api/[controller]/action")]
    [ApiController]
    public class ClassController : ControllerBase
    {
        private readonly IClassRepository _classRepository;

        public ClassController(IClassRepository classRepository)
        {
            _classRepository = classRepository;
        }

        [HttpGet]

        public IEnumerable<ClassDto> GetClasses()
        {
            return _classRepository.GetClasses();
        }

        [HttpGet]

        public ClassDto GetClassById(int id)
        {
            return _classRepository.GetClass(id);
        }

        [HttpPost]
        public ClassDto CreateUpdateClass(ClassDto classDto)
        {
            var updateClass = _classRepository.CreateUpdateClass(classDto);

            return updateClass;

        }

        [HttpDelete]
        public ActionResult DeleteClassById(int id)
        {

            var isDeleted = _classRepository.RemoveClass(id);

            if (isDeleted)
                return Ok();
            else
                return NotFound();
        }

        [HttpPost]
        public ActionResult AssignStudentToClassById([FromQuery]int classId, [FromBody] int[] studentIds)
        {
            var isSuccess = _classRepository.AssignStudentsToClass(studentIds, classId);
            if (isSuccess)
                return Ok();
            else
                return NotFound();
        }

        [HttpPost]
        public ActionResult AssignClassToSchoolById([FromQuery]int classId, [FromQuery]int schoolId)
        {
            var isSuccess = _classRepository.AssignClassToSchool(classId, schoolId);
            if(!isSuccess)
                return Ok();
            else
                return NotFound();
        }
    }
}
