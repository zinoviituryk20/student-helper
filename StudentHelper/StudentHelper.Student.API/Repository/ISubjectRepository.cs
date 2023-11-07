using StudentHelper.Student.API.Models;

namespace StudentHelper.Student.API.Repository
{
    public interface ISubjectRepository
    {
        IEnumerable<SubjectDto> GetStudentSubjects(int studentId);

        SubjectDto GetSubject(int id);
    }
}
