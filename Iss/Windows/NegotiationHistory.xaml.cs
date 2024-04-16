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
    /// Interaction logic for NegotiationHistory.xaml
    /// </summary>
    public partial class NegotiationHistory : UserControl
    {
        AdAccountService adAccountService;
        // TODO - NegotiationService has to be added after implementation, I don't want to add it now because
        // it will cause conflicts
        List<Request> requests;
        public NegotiationHistory()
        {
            InitializeComponent();
            // PopulateRequests();
        }

        private void PopulateRequests()
        {
            throw new NotImplementedException();
        }

        private void homeButton_Click(object sender, RoutedEventArgs e)
        {
            HomePage homePage = new();
            if (Window.GetWindow(this) is MainWindow mainWindow)
            {
                mainWindow.contentContainer.Content = homePage;
            }
        }
    }
}
