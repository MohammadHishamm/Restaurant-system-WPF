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


    }
}

