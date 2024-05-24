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

   

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            
            int maxcapacity = int.Parse(NameTextBox.Text);

           

            try
            {
                // Create an instance of the Inventory class
                Table table = new Table();

                // Add the item using the Inventory class method
                table.AddItemToDatabase(9, maxcapacity);

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
