using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.ViewModel
{
    public class JobSearchViewModel
    {
        public string? SearchLocation { get; set; }
        public string? SearchTitle { get; set; }
        public string? SearchJobType { get; set; }
        public int? ClientID { get; set; }


    }
}
