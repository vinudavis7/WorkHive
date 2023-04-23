using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.ViewModel
{
    public class BidsViewModel
    {

        public int BidId { get; set; }
        public int BidAmount { get; set; }
        public string JobName { get; set; }
        public string JobId { get; set; }
        public DateTime ExpectedDate { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
    }
}
