using DAL;
using Entities;
using Entities.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface
{
    public interface IReviewService
    {
        public List<Review> GetReviews();
        public bool CreateReview(ReviewRequest review);
    }
}
