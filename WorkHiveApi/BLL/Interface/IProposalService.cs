using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface
{
    public  interface IProposalService
    {
        public List<Proposal> GetProposals();
        public Proposal GetProposalDetails(int proposalId);
        public Proposal CreateProposal(Proposal proposal);
        public Proposal UpdateProposal(Proposal Proposal);
    }
}
