namespace StudentHelper.Student.API.Models
{
    public class SubjectDto
    {
        public int SubjectId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int ClassId { get; set; }

        public bool Active { get; set; }

        public ClassDto Class { get; set; }
    }
}
