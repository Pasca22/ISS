using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iss.Entity
{
    public class Request(string collaborationTitle, string adOverview, string contentRequirements, string compensation, DateTime startDate, DateTime endDate,bool influencerAccept, bool adAccountAccept)
    {
        public string collaborationTitle { get; set; } = collaborationTitle;
        public string adOverview { get; set; } = adOverview;
        public string contentRequirements { get; set; } = contentRequirements;
        public string compensation { get; set; } = compensation;
        public DateTime startDate { get; set; } = startDate;
        public DateTime endDate { get; set; } = endDate;

        public bool influencerAccept { get; set; } = influencerAccept;
        public bool adAccountAccept { get; set; } = adAccountAccept;


        public override string ToString()
        {
            return this.collaborationTitle;
        }

    }
}
