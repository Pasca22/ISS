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
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Iss.Windows
{
    /// <summary>
    /// Interaction logic for MakeRequest.xaml
    /// </summary>
    public partial class MakeRequest : UserControl
    {
        public MakeRequest(Influencer influencer, Ad selectedAd)
        {
            InitializeComponent();
            adOverview.Text = selectedAd.description;
            compensation.Text = influencer.collaborationPrice.ToString();
        }

        private void MakeRequestButton_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                //also check for the calendar selection to not be empty
                if (string.IsNullOrWhiteSpace(collaborationTitle.Text) ||
                string.IsNullOrWhiteSpace(adOverview.Text) ||
            string.IsNullOrWhiteSpace(contentRequirements.Text) || string.IsNullOrEmpty(compensation.Text) || calendar.SelectedDates.Count==0)
                {
                    MessageBox.Show("Please fill in all fields and selected a timeline");
                    return;
                }

                // get request details from input fields
                string collaborationTitleString = collaborationTitle.Text;
                string adOverviewString = adOverview.Text;
                string contentRequirementsString = contentRequirements.Text;
                string compensationString = compensation.Text;
                //get the selected dates from the calendar
                DateTime startDate = calendar.SelectedDates[0];
                string startDateString = startDate.ToString("yyyy-MM-dd");
                DateTime endDate = calendar.SelectedDates[calendar.SelectedDates.Count - 1];
                string endDateString = endDate.ToString("yyyy-MM-dd");

                // Create new Request object
                Request request = new Request(collaborationTitleString, adOverviewString, contentRequirementsString, compensationString, startDateString, endDateString,false);

                //Add the request using RequestService
               
                RequestService requestService = new RequestService();
                requestService.addRequest(request);

                // Show success message or navigate to another page
                MessageBox.Show("Request created successfully!");
                clearAll();
                AdAccountOverview accountOverview = new AdAccountOverview();
                MainWindow mainWindow = Window.GetWindow(this) as MainWindow;
                if (mainWindow != null)
                {
                    mainWindow.contentContainer.Content = accountOverview;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void clearAll()
        {
            collaborationTitle.Text = "";
            adOverview.Text = "";
            contentRequirements.Text = "";
            compensation.Text = "";
            calendar.SelectedDates.Clear();
        }
    }
}
