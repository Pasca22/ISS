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
using Iss.Service;
using Iss.Windows;

namespace Iss
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        internal HomePage homePage;
        AdAccountService adAccountService = new AdAccountService();
        public MainWindow()
        {
            InitializeComponent();
            InfluencerStart influencerStart = new InfluencerStart();
            influencerStart.Show();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = textUsername.Text;
            string password = textPassword.Text;
            try
            {
                adAccountService.login(username, password);

                // Open the new window containing the HomePage user control
                this.homePage = new HomePage();
                contentContainer.Content = homePage;
            }
            catch (InvalidOperationException)
            {
                MessageBox.Show("Invalid username or password. Please try again.");
            }
        }
    }
}
