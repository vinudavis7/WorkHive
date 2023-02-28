using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Proposals
    {
        public int proposalId { get; set; }

        [ForeignKey("jobId")]
        public int jobId { get; set; }

        [ForeignKey("freelancerId")]
        public int freelancerId { get; set; }

        public string proposalText { get; set; }

        public string proposalAttachment { get; set; }

        public DateTime DateSubmitted { get; set; }



    }
}
