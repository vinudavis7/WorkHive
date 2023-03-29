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
        private readonly IDashboardService _dashboardService;

        public DashboardController(IDashboardService dashboardService)
        {
            _dashboardService = dashboardService;
        }
        [HttpGet]
        public async Task<object> Get()
        {
            var v=await _dashboardService.GetDashboardData();
            return v;
        }
        [HttpGet]
        [Route("GetDashboardSummary")]
        public IDictionary<string, int> GetDashboardSummary()
        {
            return _dashboardService.GetDashboardSummary();
        }



    }
}
