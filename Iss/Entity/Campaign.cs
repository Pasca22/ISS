using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iss.Entity
{
    public class Campaign
    {
        public string Name { get; set; }
        public string TargetAudience { get; set; }
        public DateTime StartDate { get; set; }
        public int Duration { get; set; }

        public Campaign() { }

        public Campaign(string name, string targetAudience, DateTime startDate, int duration)
        {
            Name = name;
            TargetAudience = targetAudience;
            StartDate = startDate;
            Duration = duration;
        }
    }
}