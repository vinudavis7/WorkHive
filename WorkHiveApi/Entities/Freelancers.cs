using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Freelancers
    {
        [Key]
        public int freelancerId { get; set; }

        public string title { get; set; }

        public string description { get; set; }

        public string portfolio { get; set; }

        public string experience { get; set; }

        public double hourlyRate { get; set; }

        public string skills { get; set; }



    }
}
