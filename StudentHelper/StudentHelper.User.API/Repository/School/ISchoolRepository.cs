using StudentHelper.Admin.API.Models;

namespace StudentHelper.Admin.API.Repository
{
    public interface ISchoolRepository
    {
        IEnumerable<EducationInstitutionDto> GetEducationInstitutions();

        EducationInstitutionDto GetEducationInstitution(int educationInstitutionId);

        EducationInstitutionDto CreateUpdateEducationInstitution(EducationInstitutionDto educationInstitution);

        bool DeleteEducationInstitution(int eduationInstitutionId);
    }
}
