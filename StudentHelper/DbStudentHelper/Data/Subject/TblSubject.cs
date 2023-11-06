using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbStudentHelper.Data
{
    [Table("tblSubject")]
    public class TblSubject
    {
        [Key]
        public int SubjectId {  get; set; }

        [Column(TypeName ="nvarchar(255)"),Required]
        public string Name {  get; set; }

        public string Description {  get; set; }

        public int TeacherId {  get; set; }

        public int ClassId {  get; set; }

        public bool Active {  get; set; }

        [ForeignKey("TeacherId")]
        public TblUser Teacher { get; set; }

        [ForeignKey("ClassId")]
        public TblClass Class { get; set; }
    }
}
