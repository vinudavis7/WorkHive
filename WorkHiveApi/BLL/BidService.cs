using BLL.Interface;
using DAL;
using DAL.Repository;
using DAL.Repository.Interface;
using Entities;
using Entities.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BidService:IBidService
    {
        private readonly IBidRepository _bidRepository;
        private readonly IJobRepository _jobRepository;
        private readonly IUserRepository _userRepository;

        public BidService(IBidRepository bidRepository, IJobRepository jobRepository, IUserRepository userRepository)
        {
            _bidRepository = bidRepository;
            _jobRepository = jobRepository;
            _userRepository = userRepository;
        }
      
       
       
      
        public List<Bid> GetBids()
        {
            try
            {
                using (AppDbContext context = new AppDbContext())
                {
                    return _bidRepository.GetBids(context);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Bid GetBidDetails(int proposalId)
        {
            try
            {
                using (AppDbContext context = new AppDbContext())
                {
                    return _bidRepository.GetBidDetails(context,proposalId);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Bid CreateBid(BidRequest bid)
        {
            try
            {
                Bid bidObj = new Bid
                {
                    BidAmount = bid.BidAmount,
                    Description = bid.Description,
                    ExpectedDate = bid.ExpectedDate,
                    Status = bid.Status
                };



                using (AppDbContext context = new AppDbContext())
                {
                    User user = _userRepository.GetUserDetails(context, bid.UserId);
                    Job job = _jobRepository.GetJobDetails(context, bid.JobId);

                    _bidRepository.CreateBid(context, bidObj);
                    _userRepository.AddBidToCollection(context, bidObj, user);
                    _jobRepository.AddBidToCollection(context, bidObj, job);

                    context.SaveChanges();
                    return bidObj;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //public Bid UpdateBid(BidRequest bid)
        //{
        //    try
        //    {
        //        using (AppDbContext context = new AppDbContext())
        //        {
        //            _bidRepository.UpdateBid(context, bid);
        //            context.SaveChanges();
        //            return bid;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        public bool UpdateBidStatus(int proposalId)
        {
            try
            {
                using (AppDbContext context = new AppDbContext())
                {
                   _bidRepository.UpdateBidStatus(context,proposalId);
                context.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
