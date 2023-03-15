using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Proposal
    {
        [Key]
        public int ProposalId { get; set; }
 
        public int JobId { get; set; }

        public int FreelancerId { get; set; }
        public int BidAmount { get; set; }
        public int NumberOfDays { get; set; }
        public string ProposalDescription { get; set; }

       // public string Attachment { get; set; }

       // public DateTime DateSubmitted { get; set; }

        //[ForeignKey("JobId")]
        //public Job Job { get; set; }
        //[ForeignKey("FreelancerId")]
        //public Freelancer Freelancer { get; set; }

    }
}
