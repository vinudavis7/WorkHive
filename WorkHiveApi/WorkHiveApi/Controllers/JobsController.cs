using BLL;
using BLL.Interface;
using Entities;
using Entities.ViewModel;
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
        public   IEnumerable<Job> GetAll([FromQuery] JobSearchViewModel searchParams)
        {
            var jobList= _jobService.GetJobs(searchParams);
            return jobList;
        }
        [HttpGet]
    
        // GET api/<JobController>/5
        [HttpGet]
        [Route("GetDetails/{id}")]
        public Job Get(int id)
        {
            var details = _jobService.GetJobDetails(id);
            return details;
        }

        // POST api/<JobController>
        [HttpPost]
        public Job Post([FromBody] JobRequest job)
        {
            var jobObj = _jobService.CreateJob(job);
            return jobObj;
        }

        //PUT api/<JobController>/5
        [HttpPut]
        public Job Put([FromBody] JobRequest job)
        {
            var jobObj = _jobService.UpdateJob(job);
            return jobObj;
        }
    }
}
