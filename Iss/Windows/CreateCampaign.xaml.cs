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
    /// Interaction logic for CreateCampaign.xaml
    /// </summary>
    public partial class CreateCampaign : UserControl
    {
        AdSetService AdSetService = new AdSetService();
        CampaignService CampaignService = new CampaignService();
        public CreateCampaign()
        {
            InitializeComponent();
            itemListBox.SetValue(ItemsControl.ItemsSourceProperty, AdSetService.getAdSetsThatAreNotInCampaign());
        }

        private void createCampaignButton_Click(object sender, RoutedEventArgs e)
        {
            List<AdSet> adSets = new List<AdSet>();
            foreach (AdSet adSet in itemListBox.SelectedItems)
            {
                adSets.Add(adSet);
            }
            Campaign campaign = new Campaign(nameTextBox.Text, startDatePicker.SelectedDate.Value, int.Parse(durationTextBox.Text), adSets);
            CampaignService.addCampaign(campaign);

            MessageBox.Show("Camapign created with " + adSets.Count + " ad sets", "Camapign Created", MessageBoxButton.OK, MessageBoxImage.Information);

            AdAccountOverview adAccountOverview = new AdAccountOverview();
            this.Content = adAccountOverview;
        }
    }
}
