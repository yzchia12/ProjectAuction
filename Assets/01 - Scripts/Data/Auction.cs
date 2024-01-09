using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectBid.Data
{
    public class Auction
    {
        public string id;
        public string name;
        public string ownerId;
        public string ownerName;
        public string imagesUrl;
        public int startingPrice;
        public int buyoutPrice;
        public int shippingPrice;
        public string condition;
        public Constants.Categories category;
        public string description;
        public string highestBidderName;
        public string highestBidderId;
        public int bidNumber;
    }
}