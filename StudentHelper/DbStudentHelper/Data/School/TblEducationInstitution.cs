using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DbStudentHelper.Data
{
    [Table("tblEducationInstitution")]
    public class TblEducationInstitution
    {
        [Key]
        public int EducationInstitutionId {  get; set; }

        [Column(TypeName ="nvarchar(255)"),Required]
        public string Name {  get; set; }

        [Required]
        public int LocationId {  get; set; }

        public string Description {  get; set; }

        [ForeignKey("LocationId")]
        public TblLocation Location { get; set; }
        public ICollection<TblClass> Classes { get; set; }
    }
}
