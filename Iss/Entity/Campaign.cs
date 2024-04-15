using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iss.Entity
{
    public class Campaign
    {
        public string id { get; set; }
        public string campaignName { get; set; }
        public DateTime startDate { get; set; }
        public int duration { get; set; }

        public List<AdSet> adSets { get; set; }

        public Campaign(string campaignName, DateTime startDate, int duration)
        {
            this.campaignName = campaignName;
            this.startDate = startDate;
            this.duration = duration;
        }

        public Campaign(string campaignName, DateTime startDate, int duration, List<AdSet> adSets)
        {
            this.campaignName = campaignName;
            this.startDate = startDate;
            this.duration = duration;
            this.adSets = adSets;
        }

        public Campaign(string id, string campaignName, DateTime startDate, int duration)
        {
            this.id = id;
            this.campaignName = campaignName;
            this.startDate = startDate;
            this.duration = duration;
        }

        public override string ToString()
        {
            return "CAMPAIGN NAME: " + campaignName + "-" + "START DATE: " + startDate.ToString() + "-" + "DURATION: " + duration;
        }
    }
}