using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Categories
    {
        [Key]
        public int categoryId { get; set; }
        // [ForeignKey("category_name")]
        public string categoryName { get; set; }
    }
}
