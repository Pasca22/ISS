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
    /// Interaction logic for HomePage.xaml
    /// </summary>
    public partial class HomePage : UserControl
    {
        public HomePage()
        {
            InitializeComponent();
        }

        private void accountOverviewButton_Click(object sender, EventArgs e)
        {
            AdAccountOverview accountOverview = new AdAccountOverview();
            MainWindow mainWindow = Window.GetWindow(this) as MainWindow;
            if (mainWindow != null)
            {
                mainWindow.contentContainer.Content = accountOverview;
            }
        }


        private void NegotiationHistoryButton_Click(object sender, RoutedEventArgs e)
        {
            bool isAdAccount = true;
            ListOfRequests listOfRequests = new ListOfRequests(isAdAccount);
            MainWindow mainWindow = Window.GetWindow(this) as MainWindow;
            if (mainWindow != null)
            {
                mainWindow.contentContainer.Content = listOfRequests;
            }
        }

        private void editAccountButton_Click(object sender, RoutedEventArgs e)
        {
            EditAdAccount editAdAccount = new EditAdAccount();
            MainWindow mainWindow = Window.GetWindow(this) as MainWindow;
            if (mainWindow != null)
            {
                mainWindow.contentContainer.Content = editAdAccount;
            }

        }
    }
}
