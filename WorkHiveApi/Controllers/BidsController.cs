using BLL.Interface;
using Entities;
using Entities.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;


namespace WorkHiveApi.Controllers
{
   
    [Route("api/[controller]")]
    [ApiController]
    public class BidsController : ControllerBase
    {
        private readonly ILogger<BidsController> _logger;
        private readonly IBidService _bidService;
        public BidsController(IBidService bidService, ILogger<BidsController> logger)
        {
            _bidService = bidService;
            _logger = logger;
        }

        //endpoint to get all bids
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var bidList = _bidService.GetBids();
                return Ok(bidList);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error"); //error will be witten into a text file in the root path using serilog
                return StatusCode(StatusCodes.Status500InternalServerError, "An unexpected error occurred");
            }

        }


        [HttpPost]
        [Route("UpdateBidStatus")]
        public IActionResult UpdateBidStatus([FromBody] int bidId)
        {
            try
            {
                //to update the status of the bid
                var result = _bidService.UpdateBidStatus(bidId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error");
                return StatusCode(StatusCodes.Status500InternalServerError, "An unexpected error occurred");
            }
        }


        [HttpPost]
        public IActionResult Post([FromBody] BidRequest bid)
        {
            try
            {
                var result = _bidService.CreateBid(bid);
                if (result.BidId > 0)
                    return Ok(true);
                else
                    return Ok(false);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error");
                return StatusCode(StatusCodes.Status500InternalServerError, "An unexpected error occurred");
            }
        }
    }
}
