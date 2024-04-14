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

        public AdAccountOverview()
        {
            InitializeComponent();
            PopulateAccountDetails();
            PopulateAds();
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

        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            // Create an instance of the home page
            HomePage homePage = new HomePage();

            // Replace the current user control with the home page
            Window window = Window.GetWindow(this);
            if (window != null && window is MainWindow mainWindow)
            {
                mainWindow.contentContainer.Content = mainWindow.homePage;
            }
        }
    }
}
