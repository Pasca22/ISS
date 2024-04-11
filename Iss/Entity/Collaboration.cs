using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Resources;

namespace Iss.Entity
{
    public class Collaboration
    {
        int CollaborationId { get; set; }
        DateTime dateOfRequest { get; set; }
        bool status { get; set; }
        string campaignOverview { get; set; }
        string compensationPackage { get; set; }
        float collaborationFee { get; set; }
        string timeline { get; set; }

        public Collaboration(int CollaborationId, DateTime dateOfRequest, bool status, string campaignOverview, string compensationPackage, float collaborationFee, string timeline)
        {
            this.CollaborationId = CollaborationId;
            this.dateOfRequest = dateOfRequest;
            this.status = status;
            this.campaignOverview = campaignOverview;
            this.compensationPackage = compensationPackage;
            this.collaborationFee = collaborationFee;
            this.timeline = timeline;
        }
    }
}
