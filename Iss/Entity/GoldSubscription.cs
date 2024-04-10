using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iss.Entity
{
    public class GoldSubscription : ISubscription
    {
        private int numberOfCampaigns { get; set; }
        private decimal price { get; set; }
        private int reach { get; set; }

        public GoldSubscription(int numberOfCampaigns, decimal price, int reach)
        {
            this.numberOfCampaigns = numberOfCampaigns;
            this.price = price;
            this.reach = reach;
        }
    }
}
