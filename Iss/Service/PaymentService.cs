using Iss.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iss.Service
{
    public class PaymentService
    {
        private PaymentRepository paymentRepository;

        public PaymentService()
        {
            paymentRepository = new PaymentRepository();
        }

        public void addOneAd()
        {
            paymentRepository.addOneAd();
        }

        public void addOneAdSet()
        {
            paymentRepository.addOneAdSet();
        }

        public void addOneCampaign()
        {
            paymentRepository.addOneCampaign();
        }

        public void addBasicSubscription()
        {
            paymentRepository.addSubscription("Basic");
        }

        public void addSilverSubscription()
        {
            paymentRepository.addSubscription("Silver");
        }

        public void addGoldSubscription()
        {
            paymentRepository.addSubscription("Gold");
        }
    }
}
