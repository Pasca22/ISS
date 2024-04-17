using Iss.Entity;
using Iss.Repository;
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
    /// Interaction logic for CreateAdSet.xaml
    /// </summary>
    public partial class CreateAdSet : UserControl
    {
        AdService AdService = new AdService();
        AdSetService AdSetService = new AdSetService();
        public CreateAdSet()
        {
            InitializeComponent();
            itemListBox.SetValue(ItemsControl.ItemsSourceProperty, AdService.getAdsThatAreNotInAdSet());
            selectionComboBox.SelectedIndex = 0;
        }

        private void createAdSetButton_Click(object sender, RoutedEventArgs e)
        {
            List<Ad> ads = new List<Ad>();
            foreach (Ad ad in itemListBox.SelectedItems)
            {
                ads.Add(ad);
            }
            AdSet adSet = new AdSet(nameTextBox.Text, selectionComboBox.Text, ads);
            AdSetService.addAdSet(adSet);

            MessageBox.Show("Ad set created with " + ads.Count + " ads", "Ad Set Created", MessageBoxButton.OK, MessageBoxImage.Information);

            AdAccountOverview adAccountOverview = new AdAccountOverview();
            this.Content = adAccountOverview;
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
