
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
    /// Interaction logic for InfluencerStart.xaml
    /// </summary>
    public partial class InfluencerStart : Window
    {
        public InfluencerStart()
        {
            InitializeComponent();
        }

        private void GoToRequestsButton_Click(object sender, RoutedEventArgs e)
        {
            ListOfRequests listOfRequests = new ListOfRequests();
            InfluencerStart mainWindow = Window.GetWindow(this) as InfluencerStart;
            if (mainWindow != null)
            {
                mainWindow.contentContainer.Content = listOfRequests;
            }

        }
        private void goToCollaborationClick(object sender, RoutedEventArgs e)
        {
            bool isAdAccount = false;
            CollaborationPage collaborationPage = new CollaborationPage(isAdAccount);
            InfluencerStart mainWindow = Window.GetWindow(this) as InfluencerStart;
            if (mainWindow != null)
            {
                mainWindow.contentContainer.Content = collaborationPage;
            }

        }
    }
}
