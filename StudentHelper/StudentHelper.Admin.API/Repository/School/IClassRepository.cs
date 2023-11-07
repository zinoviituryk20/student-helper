using StudentHelper.Admin.API.Models;

namespace StudentHelper.Admin.API.Repository
{
    public interface IClassRepository
    {
        IEnumerable<ClassDto> GetClasses();

        ClassDto GetClass(int classId);

        ClassDto CreateUpdateClass(ClassDto classDto);

        bool RemoveClass(int classId);

        bool AssignClassToSchool(int classId, int schoolId);

        bool AssignStudentsToClass(int[] studentIds, int classId);
    }
}
