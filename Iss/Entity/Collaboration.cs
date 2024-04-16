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
        public DateTime startDate { get; set; }
        public bool status { get; set; }
        public string collaborationOverview { get; set; }
        public string compensationPackage { get; set; }
        public string collaborationFee { get; set; }
        public DateTime endDate { get; set; }

        public Collaboration(int CollaborationId, DateTime startDate, bool status, string collaborationOverview, string compensationPackage, string collaborationFee, int days)
        {
            this.CollaborationId = CollaborationId;
            this.startDate = startDate;
            this.status = status;
            this.collaborationOverview = collaborationOverview;
            this.compensationPackage = compensationPackage;
            this.collaborationFee = collaborationFee;
            this.endDate = startDate.AddDays(days);
        }
    }
}
