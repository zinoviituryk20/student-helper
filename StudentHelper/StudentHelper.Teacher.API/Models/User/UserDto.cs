namespace StudentHelper.Teacher.API.Models
{
    public class UserDto
    {
        public int UserId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime BirthDate { get; set; }

        public string Phone { get; set; }


        public string Address { get; set; }

        public string Description { get; set; }
    }
}
