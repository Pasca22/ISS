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
        public int CollaborationId { get; set; }
        public string collaborationTitle { get; set; }
        public DateTime startDate { get; set; }
        public bool status { get; set; }
        public string contentRequirement { get; set; }
        public string adOverview { get; set; }
        public string collaborationFee { get; set; }
        public DateTime endDate { get; set; }

        public Collaboration(int CollaborationId, DateTime startDate, bool status, string contentRequirement, string adOverview, string collaborationFee, int days, string collaborationTitle)
        {
            this.CollaborationId = CollaborationId;
            this.collaborationTitle = collaborationTitle;
            this.startDate = startDate;
            this.status = status;
            this.contentRequirement = contentRequirement;
            this.adOverview = adOverview;
            this.collaborationFee = collaborationFee;
            this.endDate = startDate.AddDays(days);
        }
        //collaborationTitle, selectedRequest.adOverview, selectedRequest.compensation, selectedRequest.startDate, selectedRequest.endDate
        public Collaboration(string collaborationTitle, string adOverview, string colaborationFee, string contentRequirement, DateTime startDate, DateTime endDate, bool status)
        {
            //this.CollaborationId = 0;
            this.collaborationTitle = collaborationTitle;
            this.startDate = startDate;
            this.status = status;
            this.contentRequirement = contentRequirement;
            this.adOverview = adOverview;
            this.collaborationFee = colaborationFee;
            this.endDate = endDate;
        }

       
    }
}
