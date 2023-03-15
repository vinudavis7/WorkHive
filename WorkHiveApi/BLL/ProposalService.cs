using BLL.Interface;
using DAL;
using DAL.Repository;
using DAL.Repository.Interface;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ProposalService:IProposalService
    {
        private readonly IProposalRepository _proposalRepository;

        public ProposalService(IProposalRepository proposalRepository)
        {
            _proposalRepository = proposalRepository;
        }
      
       
       
      
        public List<Proposal> GetProposals()
        {
            try
            {
                return _proposalRepository.GetProposals();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Proposal GetProposalDetails(int proposalId)
        {
            try
            {
                return _proposalRepository.GetProposalDetails(proposalId);
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
                return _proposalRepository.CreateProposal(proposal);
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
                return _proposalRepository.UpdateProposal(proposal);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
