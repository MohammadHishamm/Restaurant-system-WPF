using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Interaction logic for AddNewOrder.xaml
    /// </summary>
    public partial class AddNewOrder : Window
    {private List<MenuItem> menuItems;
        public AddNewOrder()
        {
            InitializeComponent();
            LoadMenuItems();
        }

        private void LoadMenuItems()
        {
            var db = new DBconfig();
            menuItems = db.GetMenuItems();

            ItemsComboBox.ItemsSource = menuItems;
            ItemsComboBox.DisplayMemberPath = "Title";
            ItemsComboBox.SelectedValuePath = "MenuItemID";
        }
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            MenuItem selectedMenuItem = ItemsComboBox.SelectedItem as MenuItem;
            if (selectedMenuItem != null)
            {
               
                string quantity = QuantityTextBox.Text;

        
                var newItem = new
                {
                    Title = selectedMenuItem.Title,
                    Price = selectedMenuItem.Price,
                    Quantity = quantity
                };

                UsersDataGrid.Items.Add(newItem);
            }
        }

        private void AddButton2_Click(object sender, RoutedEventArgs e)
        {
            try
            {
             
                if (TablesComboBox.SelectedItem == null)
                {
                    MessageBox.Show("Please select a table.");
                    return;
                }

            
                int tableID = Convert.ToInt32(((ComboBoxItem)TablesComboBox.SelectedItem).Content);

                Random random = new Random();
                int randomID = random.Next(1, 101);

                Order order = new Order();

               
                order.AddItemToDatabase(randomID, "Pending", tableID);

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
            // Close the window
            this.Close();
        }


    }
}

