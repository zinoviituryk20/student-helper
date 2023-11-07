using AutoMapper;
using DbStudentHelper;
using DbStudentHelper.Data;
using StudentHelper.Admin.API.Models;

namespace StudentHelper.Admin.API.Repository.School
{
    public class SubjectRepository : ISubjectRepository
    {
        private readonly StudentHelperDbContext _dbContext;
        private readonly IMapper _mapper;

        public SubjectRepository(StudentHelperDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public SubjectDto CreateUpdateSubject(SubjectDto subject)
        {
            var sub =_mapper.Map<TblSubject>(subject);

            if(sub.SubjectId.Equals(0))
                _dbContext.Add(sub);
            else
                _dbContext.Update(sub);

            _dbContext.SaveChanges();

            return _mapper.Map<SubjectDto>(subject);
        }

        public SubjectDto GetSubject(int subjectId)
        {
            var subject = FindSubjectById(subjectId);

            return _mapper.Map<SubjectDto>(subject);
        }

        public IEnumerable<SubjectDto> GetSubjects()
        {
            var subjects = FindAllSubjects().ToList();

            return _mapper.Map<IEnumerable<SubjectDto>>(subjects);
        }

        public bool RemoveSubject(int subjectId)
        {
            var subject = FindSubjectById(subjectId);

            if(subject == null)
                return false;

            subject.Active = false;

            _dbContext.Update(subject);
            _dbContext.SaveChanges();

            return true;
        }

        private IQueryable<TblSubject> FindAllSubjects()
        {
            return _dbContext.Subjects.AsQueryable();
        }

        private TblSubject FindSubjectById(int id)
        {
            return FindAllSubjects().FirstOrDefault(s=>s.SubjectId == id); 
        }
    }
}
