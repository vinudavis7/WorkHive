using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Bid
    {
        public int BidId { get; set; }
        public int BidAmount { get; set; }
        public DateTime ExpectedDate { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }

    }
}
