using Iss.Entity;
using Iss.Service;
using System;
using System.Windows;
using System.Windows.Controls;

namespace Iss.Windows
{
    public partial class CreateAdAccount : UserControl
    {
        public CreateAdAccount()
        {
            InitializeComponent();
            // Set the domain of activities and authorising institutions
            DomainOfActivityComboBox.ItemsSource = Constants.domainOfActivities;
            AuthorisingInstitutionComboBox.ItemsSource = Constants.authorisingInstitutions;
        }


        private void CreateAccountBtn_Click(object sender, RoutedEventArgs e)
        {
            string nameOfCompany = CompanyName.Text;
            string domainOfActivity = DomainOfActivityComboBox.Text;
            string siteUrl = SiteUrl.Text;
            string password = Password.Password;
            string taxIdentificationNumber = CIF.Text;
            string headquartersLocation = Headquarters.Text;
            string authorisingInstitution = AuthorisingInstitutionComboBox.Text;
            //TODO! implement the creation of the account
        }
    }
}
