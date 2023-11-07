using AutoMapper;
using DbStudentHelper;
using DbStudentHelper.Data;
using StudentHelper.Teacher.API.Models;

namespace StudentHelper.Teacher.API.Repository
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
        public MarkDto CreateUpdateMark(MarkDto markDto)
        {
            var mark = _mapper.Map<TblMark>(markDto);

            if(mark.MarkId.Equals(0))
                _dbContext.Add(mark);
            else
                _dbContext.Update(mark);

            _dbContext.SaveChanges();

            return _mapper.Map<MarkDto>(mark); 
        }

        public bool DeleteMark(int markId)
        {
            var mark = FindMark(markId);

            if(mark == null)
                return false;

            _dbContext.Remove(mark);
            _dbContext.SaveChanges();

            return true;
        }

        public MarkDto GetMark(int markId)
        {
            var mark = FindMark(markId);

            return _mapper.Map<MarkDto>(mark);
        }

        public IEnumerable<MarkDto> GetubjectMarks(int subjectId)
        {
            var marks = _dbContext.Marks
                .Where(m => m.SubjectId == subjectId)
                .ToList();

            return _mapper.Map<IEnumerable<MarkDto>>(marks);
        }

        private TblMark FindMark(int markId)
        {
            return _dbContext.Marks.FirstOrDefault(m => m.MarkId == markId);
        }
    }
}
