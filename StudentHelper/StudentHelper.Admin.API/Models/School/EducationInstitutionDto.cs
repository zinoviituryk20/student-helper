
namespace StudentHelper.Admin.API.Models
{
    public class EducationInstitutionDto
    {
        public int EducationInstitutionId { get; set; }

        public string Name { get; set; }

        public int LocationId { get; set; }

        public string Description { get; set; }

        public LocationDto Location { get; set; }

        public ICollection<ClassDto> Classes { get; set; }
    }
}
