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
    /// Interaction logic for SubscriptionsPage.xaml
    /// </summary>
    public partial class SubscriptionsPage : UserControl
    {
        AdAccountService adAccountService = new AdAccountService();
        public SubscriptionsPage()
        {
            InitializeComponent();
        }

        private void oneAdButton_Click(object sender, RoutedEventArgs e)
        {
            


        }
    }
}
