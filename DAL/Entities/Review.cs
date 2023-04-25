using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Review
    {
        public int ReviewId { get; set; }
        public string Description { get; set; }
        public int Rating { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
