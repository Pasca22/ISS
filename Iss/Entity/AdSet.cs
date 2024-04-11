using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iss.Entity
{
    public class AdSet
    {
        public List<Ad> ads { get;  set; }
        public List<string> targetAudience { get; set; }
        public AdSet() { }
        public AdSet(List<Ad> ads, List<string> targetAudience)
        {
            ads = ads;
            targetAudience = targetAudience;
        }

        public void addAd(Ad ad)
        {
            ads.Add(ad);
        }

        public void removeAd(Ad ad)
        {
            ads.Remove(ad);
        }
    }
}
