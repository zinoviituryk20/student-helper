using DbStudentHelper.Data;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace StudentHelper.Admin.API.Models
{
    public class ClassDto
    {
        public int ClassId { get; set; }

        public string Name { get; set; }

        public int EducationInstitutionId { get; set; }

        public int HeadTeacherId { get; set; }

        public bool Active { get; set; } = true;

        public UserDto HeadTeacher { get; set; }

        public EducationInstitutionDto EducationInstitution { get; set; }

        public ICollection<ClassStudentsDto> ClassStudents { get; set; }

        public ICollection<UserDto> Students { get; set; }
    }
}
