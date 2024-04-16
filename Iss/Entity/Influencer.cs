using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iss.Entity
{
    public class Influencer
    {
        public string userId { get; set;}
        public String name { get; set;}
        public int followerCount { get; set;}
        public int collaborationPrice { get; set;}

        public Influencer(string userId, string name, int followerCount, int collaborationPrice)
        {
            this.userId = userId;
            this.name = name;
            this.followerCount = followerCount;
            this.collaborationPrice = collaborationPrice;
        }

        public Influencer(string name, int followerCount, int collaborationPrice)
        {
            this.name = name;
            this.followerCount = followerCount;
            this.collaborationPrice = collaborationPrice;
        }

        public override string ToString()
        {
            return name + " with " + followerCount + " followers. Costs: " + collaborationPrice + "$";
        }
    }
}
