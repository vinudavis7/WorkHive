using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Reviews
    {
        [Key]
        public int reviewId { get; set; }
        [ForeignKey("clientId")]
        public int clientId { get; set; }
        [ForeignKey("freelancerId")]
        public int freelancerId { get; set; }

        public string review { get; set; }
        //public
        public DateTime DateCreated { get; set; }

    }
}
