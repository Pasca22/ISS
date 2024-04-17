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
    /// Interaction logic for EditAdAccount.xaml
    /// </summary>
    public partial class EditAdAccount : UserControl
    {
        public AdAccountService adAccountService = new AdAccountService();
        public EditAdAccount()
        {
            InitializeComponent();
        }


        private void saveChangesButton_Click_1(object sender, RoutedEventArgs e)
        {
            string nameOfCompany = companyNewNameTextBox.Text;
            string URL = newURLTextBox.Text;
            string password = newPasswordTextBox.Password;
            string location = newLocationTextBox.Text;
            adAccountService.editAdAccount(nameOfCompany, URL, password, location);
            MessageBox.Show("Changes saved successfully!");
            AdAccountOverview accountOverview = new AdAccountOverview();
            MainWindow mainWindow = Window.GetWindow(this) as MainWindow;
            if (mainWindow != null)
            {
                mainWindow.contentContainer.Content = accountOverview;
            }

        }
    }
}
