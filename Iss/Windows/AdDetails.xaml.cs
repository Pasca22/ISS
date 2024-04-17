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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Iss.Entity;
using Iss.Service;
using Microsoft.Win32;
namespace Iss.Windows
{
    /// <summary>
    /// Interaction logic for AdDetails.xaml
    /// </summary>
    public partial class AdDetails : UserControl
    {
        private Ad ad;
        private AdService adService = new AdService();
        private string selectedImagePath;
        public AdDetails(Ad ad)
        {
            this.ad = ad;
            InitializeComponent();
            FillTextBoxes();
        }

        private void FillTextBoxes()
        {
            if (ad != null)
            {
                textProductName.Text = ad.productName;
                textDescription.Text = ad.description;
                textLink.Text = ad.websiteLink;
                selectedImagePath = ad.photo;
                string selectedImageTitle = System.IO.Path.GetFileName(selectedImagePath);
                SelectedImageTitle.Text = selectedImageTitle;
               
                ClearImageButton.Visibility = Visibility.Visible;
            }
        }

        public void updateAdBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(textProductName.Text) ||
            string.IsNullOrWhiteSpace(textDescription.Text) ||
            string.IsNullOrWhiteSpace(textLink.Text) || string.IsNullOrEmpty(selectedImagePath))
                {
                    MessageBox.Show("Please fill in all fields.");
                    return;
                }

                // Retrieve ad details from input fields
                string productName = textProductName.Text;
                string description = textDescription.Text;
                string link = textLink.Text;
                
                Ad oldAd = this.adService.getAdByName(ad.productName);

                // Create Ad object
                Ad newAd = new Ad
                (
                    oldAd.id,
                    productName,
                    selectedImagePath,
                    description,
                    link
                // Add photo logic here if needed
                );

                // Add the ad using AdService
                adService.updateAd(newAd);

                // Show success message or navigate to another page
                MessageBox.Show("Ad updated successfully!");
                AdAccountOverview adAccountOverview = new AdAccountOverview();
                this.Content = adAccountOverview;

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }
        private void UploadPhotoButton_Click(object sender, RoutedEventArgs e)
        {

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files (*.jpg; *.jpeg; *.png)|*.jpg; *.jpeg; *.png|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                selectedImagePath = openFileDialog.FileName;
                string selectedImageTitle = System.IO.Path.GetFileName(selectedImagePath);
                SelectedImageTitle.Text = selectedImageTitle;

                // Show the "Clear Image" button
                ClearImageButton.Visibility = Visibility.Visible;


            }
        }
        private void ClearImageButton_Click(object sender, RoutedEventArgs e)
        {
            // Clear the selected image
            //UploadedImage.Source = null;
            selectedImagePath = "";
            SelectedImageTitle.Text = string.Empty;
            ClearImageButton.Visibility = Visibility.Collapsed;
        }

        private void deleteAdBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.adService.deleteAd(ad);
                MessageBox.Show("Ad deleted succesfully");
                AdAccountOverview adAccountOverview = new AdAccountOverview();
                this.Content = adAccountOverview;
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

        private void AccountButton_Click(object sender, RoutedEventArgs e)
        {
            AdAccountOverview adAccountOverview = new AdAccountOverview();
            this.Content = adAccountOverview;
        }

    }
}
