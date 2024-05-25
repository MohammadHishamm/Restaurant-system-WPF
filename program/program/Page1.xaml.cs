using program;
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

namespace SideBar_Nav.Pages
{
    /// <summary>
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class Page1 : Page
    {
        private Order order;
        private User _user;


        public Page1()
        {
            InitializeComponent();
            order = new Order();
            LoadDataGrid();
        }

        public Page1(User user) 
        {
            InitializeComponent();
            _user = user; 
            order = new Order();
            LoadDataGrid();
        }

        private void AddNewOrder_Click(object sender, RoutedEventArgs e)
        {
            AddNewOrder addItemWindow = new AddNewOrder(_user);
            addItemWindow.ShowDialog();
        }

        private void LoadDataGrid()
        {
            try
            {
                List<Order> orders = order.LoadItemsFromDatabase();
                UsersDataGrid.ItemsSource = orders;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading items: {ex.Message}");
            }
       
        }

        private void deleteitem_click(object sender, RoutedEventArgs e)
        {
            var selectedItem = UsersDataGrid.SelectedItem;

            if (selectedItem != null)
            {
                // Assuming the DataGrid is bound to a collection of Order objects
                Order selectedOrder = (Order)selectedItem;

                try
                {
                    selectedOrder.DeleteItemFromDatabase(selectedOrder.OrderID);
                    MessageBox.Show("Order deleted successfully.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error deleting order: {ex.Message}");
                }
            }
           
        }



    }
}