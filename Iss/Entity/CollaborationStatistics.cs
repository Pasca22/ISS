using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iss.Entity
{
    public class CollaborationStatistics
    {
        int CollaborationId { get; set; }
        int ClickThroughRate { get; set; }
        int totalImpression { get; set; }
        int likes { get; set; }
        int shares { get; set; }

        public CollaborationStatistics(int CollaborationId, int ClickThroughRate, int totalImpression, int likes, int shares)
        {
            this.CollaborationId = CollaborationId;
            this.ClickThroughRate = ClickThroughRate;
            this.totalImpression = totalImpression;
            this.likes = likes;
            this.shares = shares;
        }
    }
}
