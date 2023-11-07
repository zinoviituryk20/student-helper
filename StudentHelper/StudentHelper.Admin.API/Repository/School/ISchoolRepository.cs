using StudentHelper.Admin.API.Models;

namespace StudentHelper.Admin.API.Repository
{
    public interface ISchoolRepository
    {
        public IEnumerable<EducationInstitutionDto> GetEducationInstitutions();

        public EducationInstitutionDto GetEducationInstitution(int educationInstitutionId);

        public EducationInstitutionDto CreateUpdateEducationInstitution(EducationInstitutionDto educationInstitution);

        public bool DeleteEducationInstitution(int eduationInstitutionId);
    }
}
