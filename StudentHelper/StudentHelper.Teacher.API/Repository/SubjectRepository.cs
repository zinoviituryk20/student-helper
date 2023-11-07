using AutoMapper;
using DbStudentHelper;
using StudentHelper.Teacher.API.Models;

namespace StudentHelper.Teacher.API.Repository
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
        public SubjectDto GetSubject(int subjectId)
        {
            var subject = _dbContext.Subjects.FirstOrDefault(s=>s.SubjectId == subjectId);

            return _mapper.Map<SubjectDto>(subject);
        }

        public IEnumerable<SubjectDto> GetTeacherSubjects(int teacherId)
        {
            var subjects = _dbContext.Subjects
                .Where(s => s.TeacherId == teacherId && s.Active);

            return _mapper.Map<IEnumerable<SubjectDto>>(subjects);
        }
    }
}
