

namespace StudentHelper.Teacher.API.Models
{
    public class MarkDto
    {
        public int MarkId { get; set; }

        public int Mark { get; set; }

        public string Description { get; set; }

        public int SubjectId { get; set; }

        public int StudentId { get; set; }


        public UserDto User { get; set; }

        public SubjectDto Subject { get; set; }
    }
}
