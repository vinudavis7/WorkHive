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
        public int ReviewId { get; set; }

        public int ClientId { get; set; }
        public int FreelancerId { get; set; }

        public string Review { get; set; }
        public string Rating { get; set; }

        public DateTime DateCreated { get; set; }
        [ForeignKey("ClientId")]
        public Clients Client { get; set; }
        [ForeignKey("FreelancerId")]
        public Freelancers Freelancer { get; set; }
    }
}
