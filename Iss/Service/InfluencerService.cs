using Iss.Entity;
using Iss.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iss.Service
{
    public class InfluencerService
    {
        InfluencerRepository influencerRepository = new InfluencerRepository();
        public List<Influencer> GetInfluencers()
        {
            return influencerRepository.GetInfluencers();
        }
    }
}
