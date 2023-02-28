using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Clients
    {
        [Key]
        public int UserId { get; set; }

        public string CompanyName { get; set; }

        public string Website { get; set; }
    }
}
