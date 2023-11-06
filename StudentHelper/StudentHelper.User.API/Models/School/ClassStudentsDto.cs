
namespace StudentHelper.Admin.API.Models
{
    public class ClassStudentsDto
    {
        public int Id { get; set; }

        public int ClassId { get; set; }

        public int StudentId { get; set; }

        public UserDto Student { get; set; }

        public ClassDto Class { get; set; }
    }
}
