﻿using Entities;
using Entities.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface
{
    public  interface IBidService
    {
        public List<Bid> GetBids();
        //public List<Bid> GetProposalsToClients(int clientId);
        public Bid GetBidDetails(int bidId);
        public Bid CreateBid(BidRequest bid);
        //public Bid UpdateBid(BidRequest bid);
        public bool UpdateBidStatus(int bidId);

    }
}
