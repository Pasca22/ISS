using Iss.Entity;
using Iss.Service;
using System;
using System.Collections.Generic;
using System.Linq;
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
    /// Interaction logic for CreateAd.xaml
    /// </summary>
    public partial class CreateAd : UserControl
    {
        private AdService adService = new AdService();
        public CreateAd()
        {
            InitializeComponent();
        }

        private void SubmitAdButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Retrieve ad details from input fields
                string productName = textProductName.Text;
                string description = textDescription.Text;
                string link = textLink.Text;

                // Create Ad object
                Ad ad = new Ad
                (
                    productName,
                    "hardcoded",
                    description,
                    link
                    // Add photo logic here if needed
                );

                // Add the ad using AdService
                adService.addAd(ad);

                // Show success message or navigate to another page
                MessageBox.Show("Ad created successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
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
