using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iss.Entity
{
    public class Request(string purpose, string campaignOverview, string contentRequirements, string compensationPackage, string collaborationFee, string timeline, string legalAgreements)
    {
        public string purpose { get; set; } = purpose;
        public string campaignOverview { get; set; } = campaignOverview;
        public string contentRequirements { get; set; } = contentRequirements;
        public string compensationPackage { get; set; } = compensationPackage;
        public string collaborationFee { get; set; } = collaborationFee;
        public string timeline { get; set; } = timeline;
        public string legalAgreements { get; set; } = legalAgreements;
    }
}
