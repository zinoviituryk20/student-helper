﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbStudentHelper.Data
{
    [Table("ztblClassStudent")]
    public class ZtblClassStudent
    {
        [Key]
        public int Id { get; set; }

        public int ClassId {  get; set; }

        public int StudentId { get; set; }

        [ForeignKey("StudentId")]
        public TblUser Student { get; set; }

        [ForeignKey("ClassId")]
        public TblClass Class { get; set; }
    }
}
