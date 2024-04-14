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

            // go back to account overview
            AdAccountOverview adAccountOverview = new AdAccountOverview();
            this.Content = adAccountOverview;
        }
    }
}
