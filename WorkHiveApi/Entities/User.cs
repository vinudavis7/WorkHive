using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class User
    {
        public int UserId { get; set; }
        public string  Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Location { get; set; }
        public string UserType { get; set; }
        public string ProfileImage { get; set; }
        public string Password { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
