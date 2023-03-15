using BLL.Interface;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WorkHiveApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProposalsController : ControllerBase
    {
        private readonly IProposalService _proposalService;
        public ProposalsController(IProposalService proposalService)
        {
            _proposalService = proposalService;
        }
        // GET: api/<ProposalController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ProposalController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ProposalController>
        [HttpPost]
        public bool Post([FromBody] Proposal proposal)
        {try
            {
                var jobObj = _proposalService.CreateProposal(proposal);
                if (jobObj.ProposalId > 0)
                    return true;
                else return false;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        // PUT api/<ProposalController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ProposalController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
