using Iss.Entity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using Iss.Service;
using System.Collections.Specialized;

namespace Iss.Windows
{
    /// <summary>
    /// Interaction logic for ListOfRequests.xaml
    /// </summary>
    public partial class ListOfRequests : UserControl
    {
        private RequestService requestService = new RequestService();
        private CollaborationService collaborationService = new CollaborationService();
        
        public List<Request> requests { get; set; }
        public ListOfRequests(bool isAdAccount)
        {
            InitializeComponent();
            PopulateRequests();
            this.isAdAccount = isAdAccount;
        }

        private void PopulateRequests()
        {
            if(isAdAccount)
            {
                // Get requests for the current user
                requests = requestService.getRequestsForAdAccount();
            }
            else
            {
                // Get requests for the current user
                requests = requestService.getRequestsForInfluencer();
            }

            requestsListView.Items.Clear();
            foreach (var request in requests)
            {
                requestsListView.Items.Add(request.collaborationTitle);
            }


        }

        private void DetailsButton_Click(object sender, RoutedEventArgs e)
        {

            if (requestsListView.SelectedItem != null)
            {

            }
            else
            {
                MessageBox.Show("Please select a request!");
            }
        }

        private void AcceptButton_Click(object sender, RoutedEventArgs e)
        {
            if (requestsListView.SelectedItem != null)
            {

                try
                {
                    string collaborationTitle = (string)requestsListView.SelectedItem;
                    Request selectedRequest = requestService.getRequestWithTitle(collaborationTitle);
                    selectedRequest.influencerAccept = true;
                    requestService.deleteRequest(selectedRequest);
                    
                    Collaboration collaboration = new Collaboration(collaborationTitle, selectedRequest.adOverview, selectedRequest.compensation, selectedRequest.contentRequirements, DateTime.Parse(selectedRequest.startDate), DateTime.Parse(selectedRequest.endDate), true);
                  
                    collaborationService.addCollaboration(collaboration);
                    MessageBox.Show("Request accepted. A new collaboration was created!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }

            }
            else
            {
                MessageBox.Show("Please select a request to accept!");
            }


        }

        private void DeclineButton_Click(object sender, RoutedEventArgs e)
        {
            if (requestsListView.SelectedItem != null)
            {
                try
                {
                    string collaborationTitle = (string)requestsListView.SelectedItem;
                    Request selectedRequest = requestService.getRequestWithTitle(collaborationTitle);
                    selectedRequest.influencerAccept = false;
                    requestService.deleteRequest(selectedRequest);
                    MessageBox.Show("Request declined. The request was deleted!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Please select a request to decline!");
            }
        }


        private void NegociateButton_Click(object sender, RoutedEventArgs e)
        {

            if (requestsListView.SelectedItem != null)
            {
                try
                {
                    string collaborationTitle = (string)requestsListView.SelectedItem;
                    Request selectedRequest = requestService.getRequestWithTitle(collaborationTitle);
                    //open negociation page

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Please select a request to negociate!");
            }

        }

        private void StartPageButton_Click(object sender, RoutedEventArgs e)
        {

            //Go back to the influencer start window as main window
            //Reverse the changes made here
            /*
             ListOfRequests listOfRequests = new ListOfRequests();
             InfluencerStart mainWindow = Window.GetWindow(this) as InfluencerStart;
             if (mainWindow != null)
             {
                 mainWindow.contentContainer.Content = listOfRequests;
             }
             */


        }
    }
}
