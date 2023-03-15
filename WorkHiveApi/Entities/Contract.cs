using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Contract
    {
        [Key]
        public int ContractId { get; set; }
        public int JobId { get; set; }
        public int ClientId { get; set; }
        public int FreelancerId { get; set; }
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public DateTime DateCreated { get; set; }
        public string PaymentTerms { get; set; }
        [ForeignKey("JobId")]
        public Job Job { get; set; }
        [ForeignKey("ClientId")]
        public Client Client { get; set; }
        [ForeignKey("FreelancerId")]
        public Freelancer Freelancer { get; set; }

    }
}
