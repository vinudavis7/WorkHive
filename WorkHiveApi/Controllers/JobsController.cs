using BLL;
using BLL.Interface;
using Entities;
using Entities.ViewModel;
using Microsoft.AspNetCore.Mvc;


namespace WorkHiveApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobsController : ControllerBase
    {
        private readonly ILogger<JobsController> _logger;
        private readonly IJobService _jobService;

        public JobsController(IJobService jobService, ILogger<JobsController> logger)
        {
            _jobService = jobService;
            _logger = logger;
        }
        //to get jobs based on search criteria
        //if search parameters are null, will return all the jobs from database
        [HttpGet]
        public IActionResult GetAll([FromQuery] JobSearchViewModel searchParams)
        {
            try
            {
                var jobList = _jobService.GetJobs(searchParams);
                return Ok(jobList);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error");
                return StatusCode(StatusCodes.Status500InternalServerError, "An unexpected error occurred");
            }
        }

        [HttpGet]
        [Route("GetDetails/{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var details = _jobService.GetJobDetails(id);
                return Ok(details);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error");
                return StatusCode(StatusCodes.Status500InternalServerError, "An unexpected error occurred");
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] JobRequest job)
        {
            try
            {
                var result = _jobService.CreateJob(job);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error");
                return StatusCode(StatusCodes.Status500InternalServerError, "An unexpected error occurred");
            }
        }

        [HttpPut]
        public IActionResult Put([FromBody] UpdateJobRequest job)
        {
            try
            {
                var result = _jobService.UpdateJob(job);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error");
                return StatusCode(StatusCodes.Status500InternalServerError, "An unexpected error occurred");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var result=_jobService.DeleteJob(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error");
                return StatusCode(StatusCodes.Status500InternalServerError, "An unexpected error occurred");
            }
        }

        //this endpoint will be called by Azure functions scheduler to send email notifications about the jobs posted daily
        [HttpPost]
        [Route("SendNotifications")]
        public IActionResult SendNotifications()
        {
            try
            {
                var result = _jobService.SendNotifications();
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error");
                return StatusCode(StatusCodes.Status500InternalServerError, "An unexpected error occurred");
            }
        }


    }
}
