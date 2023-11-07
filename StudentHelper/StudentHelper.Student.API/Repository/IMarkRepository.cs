using StudentHelper.Student.API.Models.School;

namespace StudentHelper.Student.API.Repository
{
    public interface IMarkRepository
    {
        IEnumerable<MarkDto> GetStudentsMark(int studentId);

        IEnumerable<MarkDto> GetStudentSubjectMark(int studentId, int subjectId);

        MarkDto GetMark(int markId);
    }
}
