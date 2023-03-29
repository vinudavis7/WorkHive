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
                //else
                //    list = _dbContext.Bids.Where(x => x == userId).ToList();

        //        var proposalsWithJobs = list
        //.Join(
        //    _dbContext.Jobs, proposal => proposal.JobId, job => job.JobId,
        //    (proposal, job) => new { Proposal = proposal, Job = job }
        //)
        //.Select(pj => new Proposal
        //{
        //    ProposalDescription = pj.Proposal.ProposalDescription,
        //    NumberOfDays = pj.Proposal.NumberOfDays,
        //    ProposalId = pj.Proposal.ProposalId,
        //    BidAmount = pj.Proposal.BidAmount,
        //    JobId = pj.Proposal.JobId,
        //    Status = pj.Proposal.Status,
        //    Job = pj.Job
        //}).ToList();

                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //public List<Bid> GetBidsToClients(AppDbContext _dbContext, int clientId)
        //{
        //    try
        //    {

        //        var result = _dbContext.Proposals
        //.Join(_dbContext.Jobs, p => p.JobId, j => j.JobId, (p, j) => new { Proposal = p, Job = j })
        //.Join(_dbContext.Clients, x => x.Job.ClientId, c => c.UserId, (x, c) => new { Proposal = x.Proposal, Job = x.Job, Client = c })
        //.Join(_dbContext.Users, x => x.Proposal.FreelancerId, u => u.UserId, (x, u) =>
        //new Proposal
        //{
        //    ProposalDescription = x.Proposal.ProposalDescription,
        //    NumberOfDays = x.Proposal.NumberOfDays,
        //    ProposalId = x.Proposal.ProposalId,
        //    BidAmount = x.Proposal.BidAmount,
        //    JobId = x.Proposal.JobId,
        //    Status = x.Proposal.Status,
        //    Job = x.Job,
        //    Freelancer = new Freelancer { UserDetails = u }
        //}).Where(x => x.Job.ClientId == clientId).ToList();
        //        return result;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

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


                //var bidsToUpdate = _dbContext.Bids.Where(p => p == bid.JobId && p.ProposalId != proposal.ProposalId);

                //foreach (var obj in bidsToUpdate)
                //{
                //    obj.Status = "Rejected";
                //}
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
