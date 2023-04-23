using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository.Interface
{
    public interface IReviewRepository
    {
        public List<Review> GetReviews(AppDbContext context);
        public Review CreateReview(AppDbContext context, Review review);
    }
}
