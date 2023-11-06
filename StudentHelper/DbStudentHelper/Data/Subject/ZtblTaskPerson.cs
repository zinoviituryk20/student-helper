using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbStudentHelper.Data
{
    [Table("ztblTaskPerson")]
    public class ZtblTaskPerson
    {
        public int Id { get; set; }

        public int TaskId { get; set; }

        public int StudentId { get; set; }

        public int MarkId { get; set; }

        [ForeignKey("TaskId"), DeleteBehavior(DeleteBehavior.NoAction)]
        public TblTask Task { get; set; }

        [ForeignKey("StudentId"), DeleteBehavior(DeleteBehavior.NoAction)]
        public TblUser Student { get; set; }

        [ForeignKey("MarkId"), DeleteBehavior(DeleteBehavior.NoAction)]
        public TblMark Mark { get; set; }
    }
}
