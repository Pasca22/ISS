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
using System.Xml.Linq;
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

        public void deleteBtn_Click(object sender, EventArgs e)
        {
            try
            {
                this.campaignService.deleteCampaign(campaign);
                MessageBox.Show("Campaign deleted succesfully");
                AdAccountOverview adAccountOverview = new AdAccountOverview();
                this.Content = adAccountOverview;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        public void updateBtn_Click(Object sender, EventArgs e)
        {
            
            if (string.IsNullOrEmpty(nameTextBox.Text) || string.IsNullOrEmpty(durationTextBox.Text))
            {
                MessageBox.Show("Target audience and name must not be empty!");
                return; // Exit the method without performing the update
            }

            if (itemListBox1.Items.Count == 0)
            {
                MessageBox.Show("Please select at least one item from the first list!");
                return; // Exit the method without performing the update
            }

            if (itemListBox1.Items.Count == 0)
            {
                MessageBox.Show("Please select at most 10 ad sets!");
                return; // Exit the method without performing the update
            }
            if (startDatePicker.SelectedDate == null)
            {
                MessageBox.Show("Please select a start date!");
                return; // Exit the method without performing the update
            }


            try
            {
                Campaign newCampaign = new Campaign(campaign.id, nameTextBox.Text, startDatePicker.SelectedDate.Value, int.Parse(durationTextBox.Text));
                campaignService.updateCampaign(newCampaign);
                foreach (AdSet adset in itemListBox1.Items)
                {
                    this.campaignService.addAdSetToCampaign(newCampaign, adset);
                }
                foreach (AdSet adset in itemListBox2.Items)
                {
                    this.campaignService.deleteAdSetFromCampaign(newCampaign, adset);
                }

                MessageBox.Show("Campaign updated");

                AdAccountOverview adAccountOverview = new AdAccountOverview();
                this.Content = adAccountOverview;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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
