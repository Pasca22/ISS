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
using System.Collections;

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
        private bool isAdAccount;
        public ListOfRequests(bool isAdAccount)
        {
            InitializeComponent();
            PopulateRequests();
            this.isAdAccount = isAdAccount;
        }

        private void PopulateRequests()
        {
            if (isAdAccount)
            {
                // Get requests for the current user
                requests = requestService.getRequestsForAdAccount();
            }
            else
            {
                // Get requests for the current user
                requests = requestService.getRequestsForInfluencer();
            }

            requestsListView.SetValue(ItemsControl.ItemsSourceProperty, requests);



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
                    Request request = (Request)requestsListView.SelectedItem;
                    Request selectedRequest = requestService.getRequestWithTitle(request.collaborationTitle);
                    selectedRequest.influencerAccept = true;
                    requestService.deleteRequest(selectedRequest);


                    Collaboration collaboration = new Collaboration(request.collaborationTitle, selectedRequest.adOverview, selectedRequest.compensation, selectedRequest.contentRequirements, selectedRequest.startDate, selectedRequest.endDate, true);

                    collaborationService.addCollaboration(collaboration);
                    MessageBox.Show("Request accepted. A new collaboration was created!");
                    this.Content = new ListOfRequests(this.isAdAccount);
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
                    Request request = (Request)requestsListView.SelectedItem;
                    Request selectedRequest = requestService.getRequestWithTitle(request.collaborationTitle);
                    selectedRequest.influencerAccept = false;
                    requestService.deleteRequest(selectedRequest);
                    MessageBox.Show("Request declined. The request was deleted!");
                    this.Content = new ListOfRequests(this.isAdAccount);

                    //requestsListView.ItemsSource = null;
                    //requestsListView.ItemsSource = requests;


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
                    Request request = (Request)requestsListView.SelectedItem;
                    Request selectedRequest = requestService.getRequestWithTitle(request.collaborationTitle);
                    //open negociation page
                    NegotiationPage negociationPage = new NegotiationPage(selectedRequest, isAdAccount);
                    //go to the negociation page
                    InfluencerStart mainWindow = Window.GetWindow(this) as InfluencerStart;
                    if (mainWindow != null)
                    {
                        mainWindow.contentContainer.Content = negociationPage;
                    }

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
            InfluencerStart start = new InfluencerStart();
            InfluencerStart influencerStart = Window.GetWindow(this) as InfluencerStart;
            if (influencerStart != null)
            {
                influencerStart.contentContainer.Content = start.Content;
            }
        }
    }
}
