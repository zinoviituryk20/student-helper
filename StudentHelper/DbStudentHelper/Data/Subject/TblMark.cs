using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbStudentHelper.Data
{
    [Table("tblMark")]
    public class TblMark
    {
        [Key]
        public int MarkId {  get; set; }

        [Required]
        public int Mark {  get; set; }

        public string Description {  get; set; }

        public int SubjectId {  get; set; }

        public int StudentId { get; set; }

        [ForeignKey("StudentId")]
        public TblUser User { get; set; }

        [ForeignKey("SubjectId")]
        public TblSubject Subject { get; set; }

    }
}
