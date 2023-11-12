using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace StudentHelper.User.API.Models
{
    public class UserDto
    {
        public int UserId { get; set; }

        [Column(TypeName = "nvarchar(255)"), Required]
        public string Email { get; set; }

        [Column(TypeName = "nvarchar(255)"), Required]
        public string Password { get; set; }


        [Required, Column(TypeName = "varchar(255)")]
        public string FirstName { get; set; }

        [Required, Column(TypeName = "varchar(255)")]
        public string LastName { get; set; }

        public DateTime BirthDate { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string Phone { get; set; }

        [Column(TypeName = "varchar(500)")]
        public string Address { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }
    }
}
