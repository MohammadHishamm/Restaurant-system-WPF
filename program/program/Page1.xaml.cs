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
        public Page1()
        {
            InitializeComponent();
            order = new Order();
            LoadDataGrid();
        }

        private void AddNewOrder_Click(object sender, RoutedEventArgs e)
        {
            AddNewOrder addItemWindow = new AddNewOrder();
            addItemWindow.ShowDialog();
        }

        private void LoadDataGrid()
        {
            try
            {
                // Load items from the database
                order.LoadItemsFromDatabase();
               


            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading items: {ex.Message}");
            }
        }




    }
}