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
        private PaymentService paymentService = new();
        public SubscriptionsPage()
        {
            InitializeComponent();
        }

        private void oneAdButton_Click(object sender, RoutedEventArgs e)
        {
            paymentService.addOneAd();
            int totalAmountToPay = 5;
            Payment paymentPage = new Payment(totalAmountToPay);
            MainWindow? mainWindow = Window.GetWindow(this) as MainWindow;
            if (mainWindow != null)
            {
                mainWindow.contentContainer.Content = paymentPage;
            }
        }

        private void oneAdSetButton_Click(object sender, RoutedEventArgs e)
        {
            paymentService.addOneAdSet();
            int totalAmountToPay = 20;
            Payment paymentPage = new Payment(totalAmountToPay);
            MainWindow? mainWindow = Window.GetWindow(this) as MainWindow;
            if (mainWindow != null)
            {
                mainWindow.contentContainer.Content = paymentPage;
            }
        }

        private void oneCampaignButton_Click(object sender, RoutedEventArgs e)
        {
            paymentService.addOneCampaign();
            int totalAmountToPay = 150;
            Payment paymentPage = new Payment(totalAmountToPay);
            MainWindow? mainWindow = Window.GetWindow(this) as MainWindow;
            if (mainWindow != null)
            {
                mainWindow.contentContainer.Content = paymentPage;
            }
        }

        private void basicSubscriptionButton_Click(object sender, RoutedEventArgs e)
        {
            paymentService.addBasicSubscription();
            int totalAmountToPay = 250;
            Payment paymentPage = new Payment(totalAmountToPay);
            MainWindow? mainWindow = Window.GetWindow(this) as MainWindow;
            if (mainWindow != null)
            {
                mainWindow.contentContainer.Content = paymentPage;
            }
        }

        private void silverSubscriptionButton_Click(object sender, RoutedEventArgs e)
        {
            paymentService.addSilverSubscription();
            int totalAmountToPay = 350;
            Payment paymentPage = new Payment(totalAmountToPay);
            MainWindow? mainWindow = Window.GetWindow(this) as MainWindow;
            if (mainWindow != null)
            {
                mainWindow.contentContainer.Content = paymentPage;
            }
        }

        private void goldSubscriptionButton_Click(object sender, RoutedEventArgs e)
        {
            paymentService.addGoldSubscription();
            int totalAmountToPay = 500;
            Payment paymentPage = new Payment(totalAmountToPay);
            MainWindow? mainWindow = Window.GetWindow(this) as MainWindow;
            if (mainWindow != null)
            {
                mainWindow.contentContainer.Content = paymentPage;
            }
        }
    }
}
