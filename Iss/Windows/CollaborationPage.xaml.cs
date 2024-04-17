
using Iss.Entity;
using Iss.Service;
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

namespace Iss.Windows
{
    /// <summary>
    /// Interaction logic for CollaborationPage.xaml
    /// </summary>
    public partial class CollaborationPage : UserControl
    {
        private bool isAdAccount;
        private CollaborationService collaborationService = new();
        private List<Collaboration> collaborations = new();
        public CollaborationPage(bool isAdAccount)
        {
            InitializeComponent();
            this.isAdAccount = isAdAccount;
            if (this.isAdAccount)
            {
                populateListViewAdAccount();
            }
            else
            {
                populateListView();
                this.seeStatistics.Visibility = Visibility.Hidden;
            }
        }

        public void populateListViewAdAccount()
        {
            //CollaborationService collaborationService = new();
            collaborations = collaborationService.getActiveCollaborationForAdAccount();

            foreach (Collaboration collaboration in collaborations)
            {
                ListViewItem item = new ListViewItem();
                item.Content = collaboration;
                requestListView.Items.Add(item);
            }
        }

        public void populateListView()
        {
            //CollaborationService collaborationService = new();
            collaborations = collaborationService.getCollaborationForInfluencer();

            foreach (Collaboration collaboration in collaborations)
            {
                ListViewItem item = new ListViewItem();
                item.Content = collaboration;
                requestListView.Items.Add(item);
            }
        }

        public void butonulMeuApasat(object sender, RoutedEventArgs e)
        {
            if (this.isAdAccount)
            {
                HomePage homePage = new HomePage();
                MainWindow mainWindow = Window.GetWindow(this) as MainWindow;
                if (mainWindow != null)
                {
                    mainWindow.contentContainer.Content = homePage;
                }
            }
            else
            {
                InfluencerStart influencerStart = new InfluencerStart();
                InfluencerStart mainWindow = Window.GetWindow(this) as InfluencerStart;
                if (mainWindow != null)
                {
                    mainWindow.contentContainer.Content = influencerStart.Content;
                }

            }
        }

        private void SeeStatistics_OnClick(object sender, RoutedEventArgs e)
        {

            if (this.isAdAccount) {

                //Statistics statistics = new Statistics();
                //MainWindow mainWindow = Window.GetWindow(this) as MainWindow;
                //if (mainWindow != null)
                //{
                //    mainWindow.contentContainer.Content = statistics;
                //}

            }
        }
    }
}