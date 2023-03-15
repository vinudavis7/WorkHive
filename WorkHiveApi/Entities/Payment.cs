using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Payment
    {
        [Key]
        public int PaymentId { get; set; }

        public int ContractId { get; set; }

        public int Amount { get; set; }

        public string PaymentMethod { get; set; }

        public DateTime PaymentDate { get; set; }
        [ForeignKey("ContractId")]
        public Contract Contract { get; set; }
    }
}
