
namespace StudentHelper.Admin.API.Models
{
    public class UserDto
    {
        public int UserId { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public int RoleId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime BirthDate { get; set; }

        public string Phone { get; set; }


        public string Address { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public RoleDto Role { get; set; }
    }
}
