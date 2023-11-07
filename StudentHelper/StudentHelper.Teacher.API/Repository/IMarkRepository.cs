using StudentHelper.Teacher.API.Models;

namespace StudentHelper.Teacher.API.Repository
{
    public interface IMarkRepository
    {

        IEnumerable<MarkDto> GetubjectMarks(int subjectId);

        MarkDto GetMark(int markId);

        MarkDto CreateUpdateMark(MarkDto markDto);

        bool DeleteMark(int markId);
    }
}
