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
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace program
{
    /// <summary>
    /// Interaction logic for AddNewTable.xaml
    /// </summary>
    public partial class AddNewTable : Window
    {
        
        public AddNewTable()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            
            string maxcapacity = NameTextBox.Text;

            if ( string.IsNullOrWhiteSpace(maxcapacity))
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            if (!int.TryParse(maxcapacity, out int MaxCapacity))
            {
                MessageBox.Show("Capacity must be a valid integer.");
                return;
            }

            try
            {
                // Create an instance of the Inventory class
                Table table = new Table();

                // Add the item using the Inventory class method
                table.AddItemToDatabase(5,MaxCapacity);

                MessageBox.Show("Item added successfully.");

                // Optionally, you can close the window after adding the item
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }

        }
    }
}
