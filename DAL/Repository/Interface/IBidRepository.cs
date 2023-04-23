using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository.Interface
{
    public  interface IBidRepository
    {
        public List<Bid> GetBids(AppDbContext context);
        public int GetBidCount(AppDbContext context);
        public Bid GetBidDetails(AppDbContext context,int bidId);
        public Bid CreateBid(AppDbContext context,Bid bid);
        public Bid UpdateBid(AppDbContext context,Bid bid);
        public bool UpdateBidStatus(AppDbContext context,int bidId);
    }
}
