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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.DataVisualization.Charting.Compatible;
using System.Windows.Media;
using Iss.Service;
using GrapeCity.DataVisualization;
using System.Windows.Forms.DataVisualization;
using System.Windows.Forms.DataVisualization.Charting;
using Chart = System.Windows.Controls.DataVisualization.Charting.Chart;
using Series = System.Windows.Controls.DataVisualization.Charting.Series;

namespace Iss.Windows
{
    /// <summary>
    /// Interaction logic for Statistics.xaml
    /// </summary>
    public partial class Statistics : UserControl
    {  int[] predictions =SatisticsService.RunNeuralNetwork(); 
        
        public Statistics()
        {
            InitializeComponent();
        }

        private void SharesTextBox_TextChanged(object sender, TextChangedEventArgs e)
        { TextBox textBox = sender as TextBox;
            
            if (textBox != null)
            {
                // Assuming you have a list of generated numbers, let's call it "generatedNumbersList"
                
                int sum=SatisticsService.GenerateSum(SatisticsService.firstSharesPrediction); // Generate the sum of the first prediction
                
                textBox.Text = sum.ToString(); // Set the text of the TextBox to the sum
            }
            
        }

        private void TotalImpressionsTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            
            if (textBox != null)
            {
                // Assuming you have a list of generated numbers, let's call it "generatedNumbersList"
                
                int sum=SatisticsService.GenerateSum(SatisticsService.firstTotalImpressionsPrediction); // Generate the sum of the first prediction
                
                textBox.Text = sum.ToString(); // Set the text of the TextBox to the sum
            }

        }

        private void TotalLikesTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            
            if (textBox != null)
            {
              
                int sum=SatisticsService.GenerateSum(SatisticsService.firstLikesPrediction); // Generate the sum of the first prediction
                
                textBox.Text = sum.ToString(); // Set the text of the TextBox to the sum
            }

        }
        
        private void ClickThroughRateTextBox_TextChanged(object sender, TextChangedEventArgs e)
        { TextBox textBox = sender as TextBox;
            
            if (textBox != null)
            {
                
                int sum=SatisticsService.GenerateSum(SatisticsService.firstClickThroughRatePrediction); // Generate the sum of the first prediction
                
                textBox.Text = sum.ToString(); // Set the text of the TextBox to the sum
            }
            

        }

        private void ClickThroughRateOverviewButton_Click(object sender, RoutedEventArgs e)
        {
           // int firstPrediction = SatisticsService.GetFirstClickThroughRatePrediction();

            // Generate numbers around the prediction for a week (7 days)
           // List<int> generatedNumbers = SatisticsService.GenerateNumbersAroundPrediction(firstPrediction);

            // Create a new chart
            //Chart chart = new Chart();
            //LineSeries series = new LineSeries();
            //PointCollection pc = new PointCollection();
            //series.Title = "Click Through Rate Trend";


            //for (int i = 0; i < generatedNumbers.Count; i++)
            //{
                
             
             //   pc.Add(new System.Windows.Point { X = i+1, Y = generatedNumbers[i]});
                
            //}

            //chart.DataContext = new { points = pc };
            throw new NotImplementedException();
            
        }

        private void ClickThroughRatePredictionButton_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void SharesOverviewButton_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void SharesPredictionButton_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void TotalImpressionsOverviewButton_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void TotalImpressionsPredictionButton_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
