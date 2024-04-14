using Iss.Entity;
using Iss.Service;
using Microsoft.Win32;
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
        private string selectedImagePath;
        public CreateAd()
        {
            InitializeComponent();
        }

        private void SubmitAdButton_Click(object sender, RoutedEventArgs e)
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

                // Create Ad object
                Ad ad = new Ad
                (
                    productName,
                    selectedImagePath,
                    description,
                    link
                    // Add photo logic here if needed
                );

                // Add the ad using AdService
                adService.addAd(ad);

                // Show success message or navigate to another page
                MessageBox.Show("Ad created successfully!");
                clearAll();
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

        private void clearAll()
        {
            textProductName.Text = string.Empty;
            textDescription.Text = string.Empty;
            textLink.Text = string.Empty;
            selectedImagePath = string.Empty;
            SelectedImageTitle.Text = string.Empty;
            ClearImageButton.Visibility = Visibility.Collapsed;
        }

        private void ClearImageButton_Click(object sender, RoutedEventArgs e)
        {
            // Clear the selected image
            //UploadedImage.Source = null;
            selectedImagePath = "";
            SelectedImageTitle.Text = string.Empty;
            ClearImageButton.Visibility = Visibility.Collapsed;
        }
    }


}
