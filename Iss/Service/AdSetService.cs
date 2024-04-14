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
        public AdSetRepository adSetRepository = new AdSetRepository();

        public void addAdSet(AdSet adSet)
        {
            adSetRepository.addAdSet(adSet);

            adSet = adSetRepository.getAdSetByName(adSet);

            foreach (Ad ad in adSet.ads)
            {
                adSetRepository.addAdToAdSet(adSet, ad);
            }
        }
    }
}
