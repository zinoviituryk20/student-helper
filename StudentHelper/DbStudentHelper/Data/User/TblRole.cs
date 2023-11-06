using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbStudentHelper.Data
{
    [Table("tblRole")]
    public class TblRole
    {
        [Key]
        public int RoleId {  get; set; }
        [Required,Column(TypeName ="nvarchar(255)")]
        public string Role {  get; set; }

    }
}
