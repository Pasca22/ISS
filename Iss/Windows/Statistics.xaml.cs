using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Iss.Service;
using System.Windows.Controls.DataVisualization.Charting.Compatible;
using Chart = System.Windows.Controls.DataVisualization.Charting.Chart;

namespace Iss.Windows
{
    /// <summary>
    /// Interaction logic for Statistics.xaml
    /// </summary>
    public partial class Statistics : UserControl
    {
        private static int multiple = 1;
        private int likes;
        private int shares;
        private int clickThroughRate;
        private int impression;
        public Statistics()
        {
            InitializeComponent();
            likes = multiple * 100;
            shares = multiple * 50;
            clickThroughRate = multiple * 10;
            impression = multiple * 1000;
            multiple++;

            LoadStatistics();
        }

        private void LoadStatistics()
        {
           this.TotalImpressionsTextBox.Text = impression.ToString();
            this.TotalLikesTextBox.Text = likes.ToString();
            this.SharesTextBox.Text = shares.ToString();
            this.ClickThroughRateTextBox.Text = clickThroughRate.ToString();
        }

        private void goBack_Click(object sender, RoutedEventArgs e)
        {
            CollaborationPage collaborationPage = new CollaborationPage(true);
            MainWindow mainWindow = Window.GetWindow(this) as MainWindow;
            if (mainWindow != null)
            {
                mainWindow.contentContainer.Content = collaborationPage;
            }
        }
    }
}
