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

namespace program
{
    /// <summary>
    /// Interaction logic for AddMenuItem.xaml
    /// </summary>
    public partial class AddMenuItem : Window
    {
        public AddMenuItem()
        {
            InitializeComponent();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            string name = NameTextBox.Text;
            string description= DescriptionTextBox.Text;
            decimal price = decimal.Parse(PriceTextBox.Text);

            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(description) )
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }


            try
            {
                MenuItem menuItem = new MenuItem();
             
                Random random = new Random();
                int menuid = random.Next(1, 1000);


                menuItem.AddItemToDatabase(menuid,name, description, price);

                MessageBox.Show("Item added successfully.");

              
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
          
            this.Close();
        }















    }
}
