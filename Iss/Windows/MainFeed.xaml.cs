using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using Iss.User;

namespace Iss.Windows
{
    /// <summary>
    /// Interaction logic for MainFeed.xaml
    /// </summary>
    public partial class MainFeed : UserControl
    {
        private Ad ad;
        public MainFeed(Ad ad)
        {
            InitializeComponent();
            this.ad = ad;
            populate();
        }

        private void populate()
        {
            desctiptionTextBox.Text = ad.description;
            productTitleTextBox.Text = ad.productName;
            firmaTextBox.Text = User.User.getInstance().Name;

            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(ad.photo, UriKind.RelativeOrAbsolute);
            bitmap.EndInit();
            AdImage.Source = bitmap;
        }

        private void PreviousImageButtonClick(object sender, RoutedEventArgs e)
        {

        }
        
        private void loadMoreBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(ad.websiteLink))
            {
                // Open URL in default browser
                Process.Start(new ProcessStartInfo(ad.websiteLink) { UseShellExecute = true });
            }
            else
            {
                MessageBox.Show("URL is not available for this ad.");
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
