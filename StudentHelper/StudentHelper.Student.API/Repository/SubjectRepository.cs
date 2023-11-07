using AutoMapper;
using DbStudentHelper;
using Microsoft.EntityFrameworkCore;
using StudentHelper.Student.API.Models;

namespace StudentHelper.Student.API.Repository
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

        public IEnumerable<SubjectDto> GetStudentSubjects(int studentId)
        {
            var classId = _dbContext.ClassStudents.Include(cs => cs.Class)
                .Where(cs => cs.StudentId == studentId && cs.Class.Active)
                .FirstOrDefault().ClassId;

            var subjects = _dbContext.Subjects
                .Where(s => s.ClassId == classId);

            return _mapper.Map<IEnumerable<SubjectDto>>(subjects);
        }

        public SubjectDto GetSubject(int id)
        {
            var subject = _dbContext.Subjects.FirstOrDefault(s=>s.SubjectId == id);

            return _mapper.Map<SubjectDto>(subject);
        }
    }
}
