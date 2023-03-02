using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Jobs
    {
        [Key]
        public int JobId { get; set; }
        public int CategoryId { get; set; }

        public int ClientId { get; set; }
      
        public string Title { get; set; }
        public string Location { get; set; }

        public string Description { get; set; }
        public int Budget { get; set; }
        public string SkillTags { get; set; }
        public DateTime Deadline { get; set; }
        public DateTime DatePosted { get; set; }

        [ForeignKey("ClientId")]
        public Clients Client { get; set; }
        [ForeignKey("CategoryId")]
        public Categories Category { get; set; }






    }
}
