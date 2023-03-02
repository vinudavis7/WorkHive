using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Proposals
    {
        [Key]
        public int ProposalId { get; set; }
 
        public int JobId { get; set; }

        public int FreelancerId { get; set; }

        public string ProposalDescription { get; set; }

        public string Attachment { get; set; }

        public DateTime DateSubmitted { get; set; }

        [ForeignKey("JobId")]
        public Jobs Job { get; set; }
        [ForeignKey("FreelancerId")]
        public Freelancers Freelancer { get; set; }

    }
}
