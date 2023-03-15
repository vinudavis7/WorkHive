using BLL;
using BLL.Interface;
using Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WorkHiveApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobsController : ControllerBase
    {
        private readonly IJobService _jobService;

        public JobsController(IJobService jobService)
        {
            _jobService = jobService;
        }
        // GET: api/<JobController>
        [HttpGet]
        public   IEnumerable<Job> Get()
        {
            return  _jobService.GetJobs();
        }

        // GET api/<JobController>/5
        [HttpGet("{id}")]
        public Job Get(int id)
        {
            var details = _jobService.GetJobDetails(id);
            return details;
        }

        // POST api/<JobController>
        [HttpPost]
        public Job Post([FromBody] Job job)
        {
            var jobObj = _jobService.CreateJob(job);
            return jobObj;
        }

        //PUT api/<JobController>/5
        [HttpPut("{id}")]
        public Job Put([FromBody] Job job)
        {
            var jobObj = _jobService.UpdateJob(job);
            return jobObj;
        }

        // DELETE api/<JobController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
