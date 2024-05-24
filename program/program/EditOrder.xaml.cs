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
    /// Interaction logic for EditOrder.xaml
    /// </summary>
    public partial class EditOrder : Window
    {
        private List<MenuItem> menuItems;
        public int id;
        public EditOrder()
        {
            InitializeComponent();
            LoadMenuItems();
        }

        public EditOrder( int Id):this()
        {
            id = Id;
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

        private void UpdateOrderButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                
                Order order = new Order();
               
                int newTableID = Convert.ToInt32(((ComboBoxItem)TablesComboBox.SelectedItem).Content);

                // Get new status from your UI, for example from a ComboBox or TextBox
                string newStatus = "UpdatedStatus";

                // Call the UpdateOrderInDatabase method
               order.UpdateOrderInDatabase(id, newStatus, newTableID);

                MessageBox.Show("Order updated successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating order: {ex.Message}");
            }
        }




        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            // Close the window
            this.Close();
        }
    }
}
