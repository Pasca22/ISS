using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iss.Entity
{
    public class Request(string collaborationTitle, string collaborationOverview, string contentRequirements, string compensation,string startDate, string endDate,bool influencerAccept)
    {
        public string collaborationTitle { get; set; } = collaborationTitle;
        public string collaborationOverview { get; set; } = collaborationOverview;
        public string contentRequirements { get; set; } = contentRequirements;
        public string compensation { get; set; } = compensation;
        public string startDate { get; set; } = startDate;
        public string endDate { get; set; } = endDate;

        public bool influencerAccept { get; set; } = influencerAccept;
    }
}
