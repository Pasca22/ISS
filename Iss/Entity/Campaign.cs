using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iss.Entity
{
    public class Campaign
    {
        public string campaignName { get; set; }
        public string targetAudience { get; set; }
        public DateTime startDate { get; set; }
        public int duration { get; set; }

        public Campaign() { }

        public Campaign(string campaignName, string targetAudience, DateTime startDate, int duration)
        {
            campaignName = campaignName;
            targetAudience = targetAudience;
            startDate = startDate;
            duration = duration;
        }
    }
}