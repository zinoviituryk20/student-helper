using StudentHelper.Teacher.API.Models;

namespace StudentHelper.Teacher.API.Repository
{
    public interface ISubjectRepository
    {
        IEnumerable<SubjectDto> GetTeacherSubjects(int teacherId);

        SubjectDto GetSubject(int subjectId);

    }
}
