
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Entities
{
    public class User: IdentityUser
    {


        public string Location { get; set; }
        public string? ProfileImage { get; set; }
        public Profile? Profile { get; set; }

        public virtual ICollection<Bid> Bids { get; set; } =
        new List<Bid>();
        public virtual ICollection<Review> FreelancerReviews { get; set; }
        public virtual ICollection<Review> ClientReviews { get; set; }
        public virtual ICollection<Job> Jobs { get; set; }=
        new List<Job>();



    }
}
