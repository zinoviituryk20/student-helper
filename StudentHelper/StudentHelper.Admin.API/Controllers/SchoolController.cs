using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentHelper.Admin.API.Models;
using StudentHelper.Admin.API.Repository;

namespace StudentHelper.Admin.API.Controllers
{
    [Route("api/[controller]/action")]
    [ApiController]
    public class SchoolController : ControllerBase
    {
        private readonly ISchoolRepository _schoolRepository;

        public SchoolController(ISchoolRepository schoolRepository)
        {
            _schoolRepository = schoolRepository;
        }

        [HttpGet]
        public IEnumerable<EducationInstitutionDto> GetSchools()
        {
            var schools = _schoolRepository.GetEducationInstitutions();
            return schools;
        }

        [HttpGet]
        public EducationInstitutionDto GetSchoolById(int schoolId)
        {
            var school = _schoolRepository.GetEducationInstitution(schoolId);

            return school;
        }

        [HttpPost]
        public EducationInstitutionDto CreateUpdateSchool(EducationInstitutionDto school)
        {
            var updateSchool = _schoolRepository.CreateUpdateEducationInstitution(school);

            return updateSchool;
        }

        [HttpDelete]
        public ActionResult DeleteSchoolById(int schoolId)
        {
            var success = _schoolRepository.DeleteEducationInstitution(schoolId);

            if (success)
                return Ok();
            else
                return NotFound();
        }
    }
}
