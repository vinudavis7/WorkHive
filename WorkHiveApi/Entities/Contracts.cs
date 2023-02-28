using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Contracts
    {
        [Key]
        public int contractId { get; set; }

        [ForeignKey("clientId")]
        public int clientId { get; set; }

        [ForeignKey("jobId")]
        public int jobId { get; set; }

        [ForeignKey("freelancerId")]
        public int freelancerId { get; set; }

        public string paymentTerms { get; set; }

        public DateTime startDate { get; set; }

        public DateTime endDate { get; set; }

        public DateTime DateCreated { get; set; }
    }
}
