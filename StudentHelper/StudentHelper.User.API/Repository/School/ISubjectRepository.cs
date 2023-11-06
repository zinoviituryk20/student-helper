using DbStudentHelper.Data;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using StudentHelper.Admin.API.Models;

namespace StudentHelper.Admin.API.Repository.School
{
    public interface ISubjectRepository
    {
        IEnumerable<SubjectDto> GetSubjects();

        SubjectDto GetSubject(int subjectId);

        SubjectDto CreateUpdateSubject(SubjectDto subject);

        bool RemoveSubject(int subjectId);
    }
}
