﻿using Iss.Entity;
using Iss.Service;
using System;
using System.Windows;
using System.Windows.Controls;

namespace Iss.Windows
{
    public partial class CreateAdAccount : UserControl
    {
        public AdAccountService adAccountService = new AdAccountService();
        public CreateAdAccount()
        {
            InitializeComponent();
            // Set the domain of activities and authorising institutions
            DomainOfActivityComboBox.ItemsSource = Constants.DOMAIN_OF_ACTIVITIES;
            AuthorisingInstitutionComboBox.ItemsSource = Constants.AUTHORIZING_INSTITUTIONS;
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
            AdAccount account = new AdAccount(nameOfCompany, domainOfActivity, siteUrl, password, taxIdentificationNumber, headquartersLocation, authorisingInstitution);
            adAccountService.addAdAccount(account);
            adAccountService.login(nameOfCompany, password);
            //make the main window appear after button click
            MainWindow mainWindow = Window.GetWindow(this) as MainWindow;
            mainWindow.homePage = new HomePage();
            this.Content = mainWindow.homePage;


        }
    }
}
