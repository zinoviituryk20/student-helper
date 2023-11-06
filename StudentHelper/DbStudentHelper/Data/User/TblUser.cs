using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbStudentHelper.Data
{
    [Table("tblUser")]
    public class TblUser
    {
        [Key]
        public int UserId {  get; set; }

        [Column(TypeName ="nvarchar(255)"),Required]
        public string Email { get; set; }

        [Column(TypeName = "nvarchar(255)"), Required]
        public string Password {  get; set; }

        public int RoleId { get; set; }

        [Required, Column(TypeName = "varchar(255)")]
        public string FirstName { get; set; }

        [Required, Column(TypeName = "varchar(255)")]
        public string LastName { get; set; }

        public DateTime BirthDate { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string Phone { get; set; }

        [Column(TypeName = "varchar(500)")]
        public string Address { get; set; }

        public string Description {  get; set; }

        public string ImageUrl { get; set; }

        [ForeignKey("RoleId")]
        public TblRole Role { get; set; }

        public ICollection<TblMark> StudentMarks { get; set; }

        public ICollection<ZtblClassStudent> ClassStudents { get; set; }

        public ICollection<TblClass> StudentsClasses { get; set; }

        public ICollection<TblClass> HeadTeacherClasses { get; set; }
    }
}
