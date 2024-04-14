using System;
using System.Windows;
using System.Windows.Controls;

namespace Iss.Windows
{
    public partial class CreateAdAccount : UserControl
    {
        public CreateAdAccount()
        {
            InitializeComponent();
        }

        private void CompanyName_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Handle text changed event for CompanyName TextBox
            // You can access the text entered by the user using the Text property of the TextBox
            string companyName = CompanyName.Text;
            // You can perform any necessary logic with the entered text here
        }

        private void DomainOfActivityComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Handle selection changed event for DomainOfActivity ComboBox
            // You can access the selected item using the SelectedItem property of the ComboBox
            ComboBoxItem selectedItem = (ComboBoxItem)DomainOfActivityComboBox.SelectedItem;
            string selectedDomain = selectedItem.Content.ToString();
            // You can perform any necessary logic with the selected domain here
        }

        private void AuthorisingInstitutionComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Handle selection changed event for AuthorisingInstitution ComboBox
            // You can access the selected item using the SelectedItem property of the ComboBox
            ComboBoxItem selectedItem = (ComboBoxItem)AuthorisingInstitutionComboBox.SelectedItem;
            string selectedInstitution = selectedItem.Content.ToString();
            // You can perform any necessary logic with the selected institution here
        }

        private void AddCampaign_Click(object sender, RoutedEventArgs e)
        {
            // Handle button click event for AddCampaign Button
            // This event will be triggered when the user clicks the "Sign Up" button
            // You can perform any necessary actions here, such as validating input fields and saving data
        }
    }
}
