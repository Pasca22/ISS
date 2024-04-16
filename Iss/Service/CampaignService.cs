using Iss.Entity;
using Iss.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iss.Service
{
    public class CampaignService
    {
        private CampaignRepository campaignRepository = new CampaignRepository();

        public void addCampaign(Campaign campaign)
        {
            campaignRepository.addCampaign(campaign);

            campaign = campaignRepository.getCampaignByName(campaign);

            foreach (AdSet adSet in campaign.adSets)
            {
                campaignRepository.addAdSetToCampaign(campaign, adSet);
            }
        }

        public Campaign getCampaignByName(Campaign campaign)
        {
            return campaignRepository.getCampaignByName(campaign);
        }
    }
}
