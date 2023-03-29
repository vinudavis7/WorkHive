using BLL.Interface;
using Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WorkHiveApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FreelancerController : ControllerBase
    {

        private readonly IFreelancerService _freelancerService;
        public FreelancerController(IFreelancerService freelancerService)
        {
            _freelancerService = freelancerService;
        }
        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public User Get(int id)
        {
           //var details= _freelancerService.GetFreelancerDetails(id);
            return null;
            //details;
        }


        // PUT api/<ValuesController>/5
        [HttpPost]
        public bool Post([FromBody]  User details)
        {
           // var result = _freelancerService.UpdateFreelancerDetails(details);
            return false;
            //result;
        }

    }
}
