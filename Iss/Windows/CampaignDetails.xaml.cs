using System;
using System.Collections;
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

namespace Iss.Windows
{
    /// <summary>
    /// Interaction logic for CampaignDetails.xaml
    /// </summary>
    public partial class CampaignDetails : UserControl
    {
        Campaign campaign;
        CampaignService campaignService =  new CampaignService();
        AdSetService adSetService = new AdSetService();
        List<AdSet> currentAdSets = new List<AdSet>();
        List<AdSet> availableAdSets = new List<AdSet>();

        public CampaignDetails(Campaign campaign)
        {
            InitializeComponent();
            this.campaign = campaignService.getCampaignByName(campaign);
            this.populate();
        }

        public void populate()
        {
            nameTextBox.Text = campaign.campaignName;
            durationTextBox.Text = campaign.duration.ToString();
            startDatePicker.SelectedDate = campaign.startDate;
            availableAdSets = adSetService.getAdSetsThatAreNotInCampaign();
            currentAdSets = adSetService.getAdSetsInCampaign(campaign.id);
            itemListBox2.SetValue(ItemsControl.ItemsSourceProperty, availableAdSets);
            itemListBox1.SetValue(ItemsControl.ItemsSourceProperty, currentAdSets);
        }

        private void ListBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (itemListBox1.SelectedItem != null)
            {
                // Get the selected item
                int selectedIndex = itemListBox1.SelectedIndex;
                if (selectedIndex != -1)
                {
                    currentAdSets.RemoveAt(selectedIndex);
                }
                AdSet selectedAdSet = (AdSet)itemListBox1.SelectedItem;

                // Remove the selected item from list2



                // Add the selected item to list1
                availableAdSets.Add(selectedAdSet);

                // Update the ItemsSource to refresh the ListBox display
                itemListBox1.ItemsSource = null;
                itemListBox1.ItemsSource = currentAdSets;
                itemListBox2.ItemsSource = null;
                itemListBox2.ItemsSource = availableAdSets;
            }
        }

        private void ListBox2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (itemListBox2.SelectedItem != null)
            {
                // Get the selected item
                AdSet selectedAdSet = (AdSet)itemListBox2.SelectedItem;

                // Remove the selected item from list1
                int selectedIndex = itemListBox2.SelectedIndex;
                if (selectedIndex != -1)
                {
                    availableAdSets.RemoveAt(selectedIndex);
                };

                // Add the selected item to list2
                currentAdSets.Add(selectedAdSet);

                // Update the ItemsSource to refresh the ListBox display
                itemListBox2.ItemsSource = null;
                itemListBox2.ItemsSource = availableAdSets;
                itemListBox1.ItemsSource = null;
                itemListBox1.ItemsSource = currentAdSets;
            }
        }

    }
}
