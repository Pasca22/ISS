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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Iss.Entity;

namespace Iss.Windows
{
    /// <summary>
    /// Interaction logic for AdSetDetails.xaml
    /// </summary>
    public partial class AdSetDetails : UserControl
    {
        AdService AdService = new AdService();
        AdSetService AdSetService = new AdSetService();
        AdSet adSet;
        string id;
        List<Ad> list1 = new List<Ad>();
        List<Ad> list2 = new List<Ad>();
        public AdSetDetails(AdSet adSet)
        {
            InitializeComponent();

            this.adSet = adSet;
            nameTextBox.Text = adSet.name;
            selectionComboBox.Text = adSet.targetAudience;


            list2 = AdService.getAdsThatAreNotInAdSet();
            itemListBox2.SetValue(ItemsControl.ItemsSourceProperty,list2);
            populateCurrentAds();
        }

        public void populateCurrentAds()
        {
            id = AdSetService.getAdSetByName(adSet).id;
            adSet.id = id;
            list1 = AdService.GetAdsFromAdSet(id);
            itemListBox1.SetValue(ItemsControl.ItemsSourceProperty, list1);
        }

        public void updateBtn_Click(object sender, RoutedEventArgs e)
        {
            string targetAudience = selectionComboBox.Text;

            // Get the name from the TextBox
            string name = nameTextBox.Text;

            if (string.IsNullOrEmpty(targetAudience) || string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Target audience and name must not be empty!");
                return; // Exit the method without performing the update
            }

            if (itemListBox1.Items.Count == 0)
            {
                MessageBox.Show("Please select at least one item from the first list!");
                return; // Exit the method without performing the update
            }

            try
            {
                AdSet newAdSet = new AdSet(adSet.id, name, targetAudience);
                AdSetService.updateAdSet(newAdSet);
                foreach (Ad ad in itemListBox1.Items)
                {
                    this.AdSetService.addAdToAdSet(adSet, ad);
                }
                foreach (Ad ad in itemListBox2.Items)
                {
                    this.AdSetService.removeAdFromAdSet(adSet, ad);
                }
                MessageBox.Show("Ad Set updated successfully!");
                AdAccountOverview adAccountOverview = new AdAccountOverview();
                this.Content = adAccountOverview;
            }
            catch (Exception ex) {
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
                    list1.RemoveAt(selectedIndex);
                }
                Ad selectedAd = (Ad)itemListBox1.SelectedItem;

                // Remove the selected item from list2
                
                

                // Add the selected item to list1
                list2.Add(selectedAd);

                // Update the ItemsSource to refresh the ListBox display
                itemListBox1.ItemsSource = null;
                itemListBox1.ItemsSource = list1;
                itemListBox2.ItemsSource = null;
                itemListBox2.ItemsSource = list2;
            }
        }

        private void ListBox2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (itemListBox2.SelectedItem != null)
            {
                // Get the selected item
                Ad selectedAd = (Ad)itemListBox2.SelectedItem;

                // Remove the selected item from list1
                int selectedIndex = itemListBox2.SelectedIndex;
                if (selectedIndex != -1)
                {
                    list2.RemoveAt(selectedIndex);
                };

                // Add the selected item to list2
                list1.Add(selectedAd);

                // Update the ItemsSource to refresh the ListBox display
                itemListBox2.ItemsSource = null;
                itemListBox2.ItemsSource = list2;
                itemListBox1.ItemsSource = null;
                itemListBox1.ItemsSource = list1;
            }
        }
        private void deleteBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.AdSetService.deleteAdSet(adSet);
                MessageBox.Show("Ad Set deleted succesfully");
                AdAccountOverview adAccountOverview = new AdAccountOverview();
                this.Content = adAccountOverview;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }
    }

}
