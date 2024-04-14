using Iss.Repository;
using Iss.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iss.Service
{
    internal class AdService
    {
        private AdRepository adRepository;

        public AdService()
        {
            this.adRepository = new AdRepository();
        }

        public void addAd(Ad ad)
        {
            this.adRepository.addAd(ad);
        }
    }
}
