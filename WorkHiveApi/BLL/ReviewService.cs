using BLL.Interface;
using DAL;
using DAL.Repository;
using DAL.Repository.Interface;
using Entities;
using Entities.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ReviewService:IReviewService
    {
        private readonly IReviewRepository _reviewRepository;
        private readonly IUserRepository _userRepository;

        public ReviewService(IReviewRepository reviewRepository, IUserRepository userRepository)
        {
            _reviewRepository = reviewRepository;
            _userRepository = userRepository;
        }
        public List<Review> GetReviews()
        {
            using (AppDbContext context = new AppDbContext())
            {
                return _reviewRepository.GetReviews(context);
            }
        }
        public bool CreateReview(ReviewRequest review)
        {
            try
            {
                using (AppDbContext context = new AppDbContext())
                {
                    User freelancer = context.Users.Where(x => x.Id == review.FreelancerId).Single();
                    User client = context.Users.Where(x => x.Id == review.ClientId).Single();

                    Review obj = new Review();
                    obj.Description = review.Description;
                    obj.Rating = review.Rating;
                    obj.DateCreated = DateTime.Now;

                    _reviewRepository.CreateReview(context, obj);
                    _userRepository.AddFreelancerReviewToCollection(context, obj, freelancer);
                    _userRepository.AddClientReviewToCollection(context, obj, client);

                    context.SaveChanges();
                    return true;
                }
            }catch(Exception ex)
            {
                return false;
            }
        }
    }
}
