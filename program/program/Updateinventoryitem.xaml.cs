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
    /// Interaction logic for Updateinventoryitem.xaml
    /// </summary>
    public partial class Updateinventoryitem : Window
    {
        public string ItemName { get; set; }
        public Updateinventoryitem()
        {
            InitializeComponent();
        }
        public Updateinventoryitem(string itemName) : this()
        {
      
            ItemName = itemName;

        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            string quantityStr = QuantityTextBox.Text;

            if (string.IsNullOrWhiteSpace(quantityStr))
            {
                MessageBox.Show("Please fill in the quantity field.");
                return;
            }

            if (!int.TryParse(quantityStr, out int quantity))
            {
                MessageBox.Show("Quantity must be a valid integer.");
                return;
            }

            try
            {
                
                Inventory inventory = new Inventory();

                string itemName = ItemName;

          
                inventory.UpdateItemInDatabase(itemName, quantity);

                MessageBox.Show("Item quantity updated successfully.");

              
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
