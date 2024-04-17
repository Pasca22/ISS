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
using Iss.Entity;
using Iss.User;

namespace Iss.Windows
{
    /// <summary>
    /// Interaction logic for MainFeed.xaml
    /// </summary>
    public partial class MainFeed : UserControl
    {
        private Ad ad;
        public MainFeed(Ad ad)
        {
            InitializeComponent();
            this.ad = ad;
            populate();
        }

        private void populate()
        {
            desctiptionTextBox.Text = ad.description;
            productTitleTextBox.Text = ad.productName;
            firmaTextBox.Text = User.User.getInstance().Name;
        }

        private void PreviousImageButtonClick(object sender, RoutedEventArgs e)
        {

        }
    }
}
