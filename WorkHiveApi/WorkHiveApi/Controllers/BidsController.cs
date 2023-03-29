using BLL.Interface;
using Entities;
using Entities.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WorkHiveApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BidsController : ControllerBase
    {
        private readonly IBidService _bidService;
        public BidsController(IBidService bidService)
        {
            _bidService = bidService;
        }
 
        [HttpGet]
        public IEnumerable<Bid> GetAll()
        {
            var list = _bidService.GetBids();

            return list;
        }
        

        [HttpPost]
        [Route("UpdateBidStatus")]
        public bool UpdateBidStatus([FromBody] int bidId)
        {
            var result = _bidService.UpdateBidStatus(bidId);

            return result;
        }


        [HttpPost]
        public bool Post([FromBody] BidRequest bid)
        {try
            {
                var obj = _bidService.CreateBid(bid);
                if (obj.BidId > 0)
                    return true;
                else
                    return false;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
    }
}
