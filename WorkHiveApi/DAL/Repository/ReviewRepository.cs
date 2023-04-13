using DAL.Repository.Interface;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class ReviewRepository : IReviewRepository
    {
      
        public List<Review> GetReviews(AppDbContext _dbContext)
        {
            try
            {
                var reviewList = _dbContext.Reviews.ToList();
                return reviewList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Review CreateReview(AppDbContext _dbContext, Review review)
        {
            try
            {
                _dbContext.Reviews.Add(review);
                return review;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

  }
}
