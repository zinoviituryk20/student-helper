using AutoMapper;
using DbStudentHelper;
using DbStudentHelper.Data;
using StudentHelper.Admin.API.Models;

namespace StudentHelper.Admin.API.Repository
{
    public class SchoolRepository : ISchoolRepository
    {
        private readonly StudentHelperDbContext _dbcontext;
        private readonly IMapper _mapper;
        public SchoolRepository(StudentHelperDbContext dbContext, IMapper mapper)
        {
            _dbcontext = dbContext;
            _mapper = mapper;
        }
        public EducationInstitutionDto CreateUpdateEducationInstitution(EducationInstitutionDto educationInstitution)
        {
            var educationInst = _mapper.Map<TblEducationInstitution>(educationInstitution);
            if (educationInst.EducationInstitutionId == 0)
                _dbcontext.Add(educationInst);
            else
                _dbcontext.Update(educationInst);

            _dbcontext.SaveChanges();

            return _mapper.Map<EducationInstitutionDto>(educationInst);

        }

        public bool DeleteEducationInstitution(int eduationInstitutionId)
        {
            var ei = _dbcontext.EducationInstitutions.FirstOrDefault(e => e.EducationInstitutionId == eduationInstitutionId);
            if (ei != null)
                return false;

            _dbcontext.Remove(ei);
            _dbcontext.SaveChanges();

            return true;
        }

        public EducationInstitutionDto GetEducationInstitution(int educationInstitutionId)
        {
            var educationInstitution = _dbcontext.EducationInstitutions.FirstOrDefault(ed => ed.EducationInstitutionId == educationInstitutionId);
            return _mapper.Map<EducationInstitutionDto>(educationInstitution);
        }

        public IEnumerable<EducationInstitutionDto> GetEducationInstitutions()
        {
            var educationInstitutions = _dbcontext.EducationInstitutions.ToList();
            return _mapper.Map<IEnumerable<EducationInstitutionDto>>(educationInstitutions);
        }
    }
}
