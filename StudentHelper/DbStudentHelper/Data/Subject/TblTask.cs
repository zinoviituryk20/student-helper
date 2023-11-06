using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbStudentHelper.Data
{
    [Table("tblTask")]
    public class TblTask
    {
        [Key]
        public int TaskId { get; set; }
        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public int SubjectId {  get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        [ForeignKey("SubjectId")]
        public TblSubject Subject { get; set; }
    }
}
