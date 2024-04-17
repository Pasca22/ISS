using Iss.Entity;
using Iss.Repository;
using Iss.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Iss.Service
{
    public class AdAccountService
    {
        private AdAccountRepository adAccountRepository;

        
        public AdAccountService()
        {
            adAccountRepository = new AdAccountRepository();
        }

        public void login(string username, string password)
        {
            AdAccount adAccount = adAccountRepository.GetAdAccount(username, password);
            if (adAccount != null)
            {
                User.User.getInstance().Id = adAccount.id;
                User.User.getInstance().Name = adAccount.nameOfCompany;
                User.User.getInstance().Password = adAccount.password;
            }
            else
            {
                throw new InvalidOperationException("Invalid username or password.");
            }
        }

        public AdAccount GetAccount()
        {
            return adAccountRepository.GetAdAccount(User.User.getInstance().Name, User.User.getInstance().Password);
        }

        public List<Ad> getAdsForCurrentUser() {
            return adAccountRepository.GetAdsForCurrentUser();
        }

        public List<AdSet> getAdSetsForCurrentUser()
        {
            return adAccountRepository.getAdSetsForCurrentUser();
        }

        public List<Campaign> getCampaignsForCurrentUser()
        {
            return adAccountRepository.getCampaignsForCurrentUser();
        }

        public void addAdAccount(AdAccount account)
        {
            this.adAccountRepository.AddAdAccount(account);
        }

        public void editAdAccount(String nameOfCompany, String URL, String password, String location)
        {
            this.adAccountRepository.EditAdAccount(nameOfCompany, URL, password, location);
        }
    }
}
