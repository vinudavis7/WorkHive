using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Jobs
    {
        [Key]
        public int jobId { get; set; }
        public string title { get; set; }

        public string description { get; set; }
        public int budget { get; set; }
        public DateTime deadline { get; set; }

        public int clientId { get; set; }

        public DateTime DatePosted { get; set; }

        public int categoryId { get; set; }


    }
}
