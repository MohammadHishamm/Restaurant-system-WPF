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

namespace program
{
    /// <summary>
    /// Interaction logic for Customerorderpage.xaml
    /// </summary>
    public partial class Customerorderpage : Page
    {
        private Order order;
        private User _user;
        public Customerorderpage()
        {
            InitializeComponent();
            order = new Order();
            LoadDataGrid();
        }
        public Customerorderpage(User user)
        {
            InitializeComponent();
            order = new Order();
            _user = user;
            LoadDataGrid();
        }
        private void AddNewOrder_Click(object sender, RoutedEventArgs e)
        {
            AddNewOrder addItemWindow = new AddNewOrder(_user);
            addItemWindow.ShowDialog();
        }
        private void EditOrder_Click(object sender, RoutedEventArgs e)
        {
            var selectedItem = UsersDataGrid.SelectedItem;

            int itemid = ((Order)selectedItem).OrderID;




            EditOrder editItemWindow = new EditOrder(itemid);
            editItemWindow.ShowDialog();



        }

        private void LoadDataGrid()
        {
            try
            {
                int userid =_user.GetId();
                List<Order> orders = order.LoadItemsFromDatabaseByUserId(userid);
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
