using Iss.Entity;
using Iss.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Iss.Windows
{
    /// <summary>
    /// Interaction logic for AdAccountOverview.xaml
    /// </summary>
    public partial class AdAccountOverview : UserControl
    {
        private AdAccountService adAccountService = new AdAccountService();
        public List<Ad> ads { get; set; }
        public List<AdSet> adSets { get; set; }
        public List<Campaign> campaigns { get; set; }

        public AdAccountOverview()
        {
            InitializeComponent();
            PopulateAccountDetails();
            PopulateAds();
            PopulateAdSets();
            PopulateCampaigns();
        }

        private void PopulateAds()
        {
            // Get ads for the current user
            ads = adAccountService.getAdsForCurrentUser();
            Ads.Items.Clear();
            foreach (var ad in ads)
            {
                Ads.Items.Add(ad);
            }
        }

        private void PopulateAdSets()
        {
            adSets = adAccountService.getAdSetsForCurrentUser();
            AdSetss.Items.Clear();
            foreach (var adSet in adSets)
            {
                AdSetss.Items.Add(adSet);
            }
        }

        private void PopulateCampaigns()
        {
            campaigns = adAccountService.getCampaignsForCurrentUser();
            Campaigns.Items.Clear();
            foreach (var campaign in campaigns)
            {
                Campaigns.Items.Add(campaign);
            }
        }

        private void PopulateAccountDetails()
        {
            // Get the user's account details
            AdAccount userAccount = adAccountService.GetAccount();

            // Populate the text fields
            if (userAccount != null)
            {
                companyName.Text = userAccount.nameOfCompany;
                domainOfActivity.Text = userAccount.domainOfActivity;
                CIF.Text = userAccount.taxIdentificationNumber;
                URL.Text = userAccount.siteUrl;
                address.Text = userAccount.headquartersLocation;
                legalInstitution.Text = userAccount.authorisingInstituion;
            }
        }

        private void addAdSetButton_Click(object sender, RoutedEventArgs e)
        {
            // Create an instance of the create ad set page
            CreateAdSet createAdSet = new CreateAdSet();
            // Replace the current user control with the create ad set page
            Window window = Window.GetWindow(this);
            if (window != null && window is MainWindow mainWindow)
            {
                mainWindow.contentContainer.Content = createAdSet;
            }
        }

        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            

            // Replace the current user control with the home page
            Window window = Window.GetWindow(this);
            if (window != null && window is MainWindow mainWindow)
            {
                mainWindow.contentContainer.Content = mainWindow.homePage;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SubscriptionsPage subscriptionPage = new SubscriptionsPage();
            MainWindow mainWindow = Window.GetWindow(this) as MainWindow;
            if (mainWindow != null)
            {
                mainWindow.contentContainer.Content = subscriptionPage;
            }

        }
        
        private void AddAd_Click(object sender, RoutedEventArgs e)
        {
            CreateAd createAd = new CreateAd();
            MainWindow mainWindow = Window.GetWindow(this) as MainWindow;
            if (mainWindow != null)
            {
                mainWindow.contentContainer.Content = createAd;
            }
        }

        private void searchAd_Click(object sender, RoutedEventArgs e)
        {
            ads = adAccountService.getAdsForCurrentUser();
            //filter ads by the text box
            Ads.Items.Clear();
            foreach (var ad in ads)
            {
                if (ad.productName.Contains(searchAdBox.Text))
                {
                    Ads.Items.Add(ad);
                }
            }

        }


        private void searchAdSet_Click(object sender, RoutedEventArgs e)
        {
            adSets = adAccountService.getAdSetsForCurrentUser();
            //filter ad sets by the text box
            AdSetss.Items.Clear();
            foreach (var adSet in adSets)
            {
                if (adSet.name.Contains(searchAdSetBox.Text))
                {
                    AdSetss.Items.Add(adSet);
                }
            }

        }

        private void searchCampaign_Click(object sender, RoutedEventArgs e)
        {
            campaigns = adAccountService.getCampaignsForCurrentUser();
            Campaigns.Items.Clear();
            foreach (var campaign in campaigns)
            {
                if (campaign.campaignName.Contains(searchCampaignBox.Text))
                {
                    Campaigns.Items.Add(campaign);
                }
            }
        }

        private void AddCampaign_Click(object sender, RoutedEventArgs e)
        {
            CreateCampaign createCampaign = new CreateCampaign();
            MainWindow mainWindow = Window.GetWindow(this) as MainWindow;
            if (mainWindow != null)
            {
                mainWindow.contentContainer.Content = createCampaign;
            }
        }

        private void Ads_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Check if an item is selected
            if (Ads.SelectedItem != null)
            {
                // Assuming you have a function to navigate to the new screen, 
                // pass the selected ad to it
                MainWindow mainWindow = Window.GetWindow(this) as MainWindow;
                if (mainWindow != null)
                {
                    mainWindow.contentContainer.Content = new AdDetails((Ad)Ads.SelectedItem);
                }

            }
        }

        private void RequestButton_Click(object sender, RoutedEventArgs e)
        {
             SelectInflucencerAndAd selectInflucencerAndAd = new SelectInflucencerAndAd();
             MainWindow mainWindow = Window.GetWindow(this) as MainWindow;
             if (mainWindow != null)
             {
                 mainWindow.contentContainer.Content = selectInflucencerAndAd;
             }
        }

        private void AdSets_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Check if an item is selected
            if (AdSetss.SelectedItem != null)
            {
                // Assuming you have a function to navigate to the new screen, 
                // pass the selected ad to it
                MainWindow mainWindow = Window.GetWindow(this) as MainWindow;
                if (mainWindow != null)
                {
                    mainWindow.contentContainer.Content = new AdSetDetails((AdSet)AdSetss.SelectedItem);
                }
            }

        }

        private void Campaign_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MainWindow mainWindow = Window.GetWindow(this) as MainWindow;
            if (mainWindow != null)
            {
                mainWindow.contentContainer.Content = new CampaignDetails((Campaign)Campaigns.SelectedItem);
            }
        }

        private void seeActiveCollaborationsButton_Click(object sender, RoutedEventArgs e)
        {
            bool isAdAccount = true;
            CollaborationPage activeCollaborations = new CollaborationPage(isAdAccount);
            MainWindow mainWindow = Window.GetWindow(this) as MainWindow;
            if (mainWindow != null)
            {
                mainWindow.contentContainer.Content = activeCollaborations;
            }

        }
    }
}
