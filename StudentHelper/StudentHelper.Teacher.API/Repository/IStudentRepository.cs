using StudentHelper.Teacher.API.Models;

namespace StudentHelper.Teacher.API.Repository
{
    public interface IStudentRepository
    {
        IEnumerable<UserDto> GetClassStudents(int classId);

    }
}
