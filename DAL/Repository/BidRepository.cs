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
    public class BidRepository : IBidRepository
    {

        public List<Bid> GetBids(AppDbContext _dbContext)
        {
            try
            {
                var list = _dbContext.Bids.ToList();
                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Bid GetBidDetails(AppDbContext _dbContext, int bidId)
        {
            try
            {
                return _dbContext.Bids.Where(x => x.BidId == bidId).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Bid CreateBid(AppDbContext _dbContext, Bid bid)
        {
            try
            {
                _dbContext.Bids.Add(bid);
                return bid;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Bid UpdateBid(AppDbContext _dbContext, Bid bid)
        {
            try
            {
                var obj = _dbContext.Bids.FirstOrDefault(x => x.BidId == bid.BidId);

                return bid;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int GetBidCount(AppDbContext _dbContext)
        {
            try
            {
                var count = _dbContext.Bids.Count();
                return count;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool UpdateBidStatus(AppDbContext _dbContext, int bidId)
        {
            try
            {
                var bid = _dbContext.Bids.FirstOrDefault(x => x.BidId == bidId);
                bid.Status = "Accepted";
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
