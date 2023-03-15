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
    public class ProposalRepository : IProposalRepository
    {
        private readonly AppDbContext _dbContext;

        public ProposalRepository(AppDbContext dbContext)
            {
              _dbContext = dbContext;
            }
        public List<Proposal> GetProposals()
        {
            try
            {
                return _dbContext.Proposals.ToList();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public Proposal GetProposalDetails(int proposalId)
        {
            try
            {
                return _dbContext.Proposals.Where(x => x.ProposalId == proposalId).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Proposal CreateProposal(Proposal proposal)
        {
            try
            {
                 _dbContext.Proposals.Add(proposal);
                _dbContext.SaveChanges();
                return proposal;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Proposal UpdateProposal(Proposal proposal)
        {
            try
            {
                var obj = _dbContext.Proposals.FirstOrDefault(x => x.ProposalId == proposal.ProposalId);
               
                _dbContext.SaveChanges();
                return proposal;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
