using Iss.Entity;
using Iss.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iss.Service
{
    public class AdSetService
    {
        private AdSetRepository adSetRepository = new AdSetRepository();

        public void addAdSet(AdSet adSet)
        {
            adSetRepository.addAdSet(adSet);

            adSet = adSetRepository.getAdSetByName(adSet);

            foreach (Ad ad in adSet.ads)
            {
                adSetRepository.addAdToAdSet(adSet, ad);
            }
        }

        public List<AdSet> getAdSetsThatAreNotInCampaign()
        {
            return adSetRepository.getAdSetsThatAreNotInCampaign();
        }
    }
}
