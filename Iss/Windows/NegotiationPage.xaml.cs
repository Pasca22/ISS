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
    /// Interaction logic for NegotiationPage.xaml
    /// </summary>
    public partial class NegotiationPage : UserControl
    {
        Request request;
        bool isAddAccount;
        RequestService requestService = new RequestService();
        public NegotiationPage(Request request, bool isAddAccount)
        {
            this.request = request;
            InitializeComponent();
            populateFields();
            this.isAddAccount = isAddAccount;
        }

        public void populateFields (){
            collaborationTitleTextBox.Text = request.collaborationTitle;
            compensationTextBox.Text = request.compensation;
            adOverviewTextBox.Text = request.adOverview;
            newRequirementsTextBox.Text = request.contentRequirements;
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            //go back to the request page
            ListOfRequests listOfRequests = new ListOfRequests(isAddAccount);
            this.Content = listOfRequests;
        }

        private void sendNegotiationButton_Click(object sender, RoutedEventArgs e)
        {
            // update the request with the new negotiation
            string newCompensation = newPriceTextBox.Text;
            string newContentRequirements = newRequirementsTextBox.Text;
            if (isAddAccount)
            {
                request.adAccountAccept = true;
                request.influencerAccept = false;
            }
            else
            {
                request.adAccountAccept = false;
                request.influencerAccept = true;
            }
            requestService.updateRequest(request, newCompensation, newContentRequirements);
            MessageBox.Show("Negotiation sent!");
            //go back to the request page
            ListOfRequests listOfRequests = new ListOfRequests(isAddAccount);
            this.Content = listOfRequests;
        }
    }
}
