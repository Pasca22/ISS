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

namespace Iss.Windows
{
    /// <summary>
    /// Interaction logic for Payment.xaml
    /// </summary>
    public partial class Payment : UserControl
    {
        int totalAmounttotalAmountToPay { get; set;}
        public Payment(int totalAmountToPay)
        {
            InitializeComponent();
            this.totalAmounttotalAmountToPay = totalAmountToPay;
            crazyPaymentSelection.SetValue(ComboBox.ItemsSourceProperty, Constants.CRAZY_PAYMENTS.Keys);
            crazyPaymentSelection.SelectedIndex = 0;
            
            textQuantity.Text = "* " + (this.totalAmounttotalAmountToPay / Constants.CRAZY_PAYMENTS["KFC Wings"]).ToString();
            textAmount.Text = "= " + this.totalAmounttotalAmountToPay.ToString();
        }

        private void crazyPaymentSelection_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string selectedItem = (string)crazyPaymentSelection.SelectedItem;

            textQuantity.Text = "* " + (this.totalAmounttotalAmountToPay / Constants.CRAZY_PAYMENTS[selectedItem]).ToString();
            textAmount.Text = "= " + this.totalAmounttotalAmountToPay.ToString();
        }

        private void sumbitPaymentButton_Click(object sender, RoutedEventArgs e)
        {
            if (creditCardOptionButton.IsChecked == false && crazyOptionButton.IsChecked == false)
            {
                MessageBox.Show("Please select a payment method!");
                return;
            }

            if (creditCardOptionButton.IsChecked == true)
            {
                MessageBox.Show("Payment with credit card was successful!");
            }
            else
            {
                MessageBox.Show("Crazy payment was successful!");
            }

            Window window = Window.GetWindow(this);
            if (window != null && window is MainWindow mainWindow)
            {
                mainWindow.contentContainer.Content = mainWindow.homePage;
            }
        }
    }
}
