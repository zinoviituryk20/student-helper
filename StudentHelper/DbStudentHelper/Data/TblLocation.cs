using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbStudentHelper.Data
{
    [Table("tblLocation")]
    public class TblLocation
    {
        [Key]
        public int LocationId {  get; set; }

        [Required]
        public bool Physical {  get; set; }

        public string Address {  get; set; }
    }
}
