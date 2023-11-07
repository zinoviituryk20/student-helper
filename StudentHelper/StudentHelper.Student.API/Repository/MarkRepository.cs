using AutoMapper;
using DbStudentHelper;
using DbStudentHelper.Data;
using StudentHelper.Student.API.Models.School;

namespace StudentHelper.Student.API.Repository
{
    public class MarkRepository : IMarkRepository
    {
        private readonly StudentHelperDbContext _dbContext;
        private readonly IMapper _mapper;

        public MarkRepository(StudentHelperDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public MarkDto GetMark(int markId)
        {
            var mark = FindAllMarks().FirstOrDefault(m=>m.MarkId == markId);

            return _mapper.Map<MarkDto>(mark);
        }

        public IEnumerable<MarkDto> GetStudentsMark(int studentId)
        {
            var marks = FindStudentMarks(studentId).ToList();

            return _mapper.Map<IEnumerable<MarkDto>>(marks);
        }

        public IEnumerable<MarkDto> GetStudentSubjectMark(int studentId, int subjectId)
        {
            var subjectMarks = FindStudentMarks(studentId)
                .Where(m=>m.SubjectId == subjectId)
                .ToList();

            return _mapper.Map<IEnumerable<MarkDto>>(subjectMarks);
        }


        private IQueryable<TblMark> FindAllMarks()
        {
            return _dbContext.Marks.AsQueryable();
        }

        private IQueryable<TblMark> FindStudentMarks(int studentId)
        {
            return FindAllMarks().Where(m=>m.StudentId == studentId);
        }
    }
}
