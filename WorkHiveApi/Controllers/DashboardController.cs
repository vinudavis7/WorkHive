using BLL;
using BLL.Interface;
using Entities;
using Entities.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WorkHiveApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private readonly ILogger<DashboardController> _logger;
        private readonly IDashboardService _dashboardService;

        public DashboardController(IDashboardService dashboardService, ILogger<DashboardController> logger)
        {
            _dashboardService = dashboardService;
            _logger = logger;
        }
        //data to be used in landing page
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await _dashboardService.GetDashboardData();
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error");
                return StatusCode(StatusCodes.Status500InternalServerError, "An unexpected error occurred");
            }

        }
        //data to be displayed in admin dashboard
        [HttpGet]
        [Route("GetDashboardSummary")]
        public async Task<IActionResult> GetDashboardSummary()
        {
            try
            {
                var summary = await _dashboardService.GetDashboardSummary();
                return Ok(summary);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error");
                return StatusCode(StatusCodes.Status500InternalServerError, "An unexpected error occurred");
            }
        }
    }
}
