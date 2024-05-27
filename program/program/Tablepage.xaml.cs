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
    /// Interaction logic for Tablepage.xaml
    /// </summary>
    /// 

    public partial class Tablepage : Page
    {
        private Table table;
        private User _user;
        public Tablepage()
        {
            InitializeComponent();
            table = new Table();
            LoadDataGrid();
        }
        public Tablepage(User user)
        {
            InitializeComponent();
            table = new Table();
            LoadDataGrid();
            _user = user;
        }
        private void AddNewItem_Click(object sender, RoutedEventArgs e)
        {
            AddNewTable addItemWindow = new AddNewTable();
            addItemWindow.ShowDialog();
        }

        private void LoadDataGrid()
        {
            try
            {
                List<Table> tables = table.LoadItemsFromDatabase();
                UsersDataGrid.ItemsSource = tables;
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
                Table selectedOrder = (Table)selectedItem;

                try
                {
                    selectedOrder.DeleteItemFromDatabase(selectedOrder.TableID);
                    MessageBox.Show("Table deleted successfully.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error deleting Table: {ex.Message}");
                }
            }

        }
    }



}
