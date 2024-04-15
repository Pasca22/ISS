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

        public List<Ad> getAdsThatAreNotInAdSet()
        {
            return this.adRepository.getAdsThatAreNotInAdSet();
        }

        public void updateAd(Ad ad)
        {
            this.adRepository.updateAd(ad);
        }

        public Ad getAdByName(string adName)
        {
            return this.adRepository.getAdByName(adName);   
        }

        public void deleteAd(Ad ad)
        {
            this.adRepository.deleteAd(ad);
        }

        public List<Ad> GetAdsFromAdSet(string id)
        {
            return this.adRepository.getAdsForAdSet(id);
        }
    }
}
