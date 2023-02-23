using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Users
    {
        [Key]
        public int UserId { get; set; }
        [Required,MaxLength(50)]
        public string  Name { get; set; }
        [Required, MaxLength(50)]
        public string Phone { get; set; }
        [Required, MaxLength(50)]
        public string Email { get; set; }
        [Required, MaxLength(50)]
        public string Location { get; set; }
        [Required, MaxLength(50)]
        public string UserType { get; set; }
        public string ProfileImage { get; set; }
        [Required, MaxLength(50)]
        public string Password { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
