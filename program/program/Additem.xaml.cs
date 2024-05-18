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
    /// Interaction logic for Additem.xaml
    /// </summary>
    public partial class Additem : Window
    {
        public Additem()
        {
            InitializeComponent();
        }
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            string name = NameTextBox.Text;
            string quantityStr = QuantityTextBox.Text;

            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(quantityStr))
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            if (!int.TryParse(quantityStr, out int quantity))
            {
                MessageBox.Show("Quantity must be a valid integer.");
                return;
            }

            try
            {
                // Create an instance of the Inventory class
                Inventory inventory = new Inventory();

                // Add the item using the Inventory class method
                inventory.AddItemToDatabase(name, quantity);

                MessageBox.Show("Item added successfully.");

                // Optionally, you can close the window after adding the item
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            // Close the window
            this.Close();
        }
    }
}


