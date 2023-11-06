using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbStudentHelper.Data
{
    [Table("tblClass")]
    public class TblClass
    {
        [Key]
        public int ClassId {  get; set; }
        [Column(TypeName ="nvarchar(255)")]
        public string Name { get; set; }

        public int EducationInstitutionId {  get; set; }

        public int HeadTeacherId {  get; set; }

        [DefaultValue(true)]
        public bool Active { get; set; } = true;

        public TblUser HeadTeacher { get; set; }

        [ForeignKey("EducationInstitutionId")]

        public TblEducationInstitution EducationInstitution { get; set; }

        public ICollection<ZtblClassStudent> ClassStudents { get; set; }

        public ICollection<TblUser> Students { get; set; }
    }
}
