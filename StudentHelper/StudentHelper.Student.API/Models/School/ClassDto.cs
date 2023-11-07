namespace StudentHelper.Student.API.Models
{
    public class ClassDto
    {
        public int ClassId { get; set; }

        public string Name { get; set; }

        public bool Active { get; set; } = true;

        public ICollection<UserDto> Students { get; set; }
    }
}
