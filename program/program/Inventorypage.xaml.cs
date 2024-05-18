using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
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
    /// Interaction logic for Inventorypage.xaml
    /// </summary>
    public partial class Inventorypage : Page
    {
        private Inventory inventory;
        public Inventorypage()
        {
            InitializeComponent();
            inventory = new Inventory();
            LoadDataGrid();
        }
        private void AddNewItem_Click(object sender, RoutedEventArgs e)
        {
            Additem addItemWindow = new Additem();
            addItemWindow.ShowDialog();
        }
        private void LoadDataGrid()
        {
            try
            {
                // Load items from the database
                inventory.LoadItemsFromDatabase();

                // Set the data context of the DataGrid to the inventory
                UsersDataGrid.ItemsSource = inventory.inventoryItems;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading items: {ex.Message}");
            }
        }

    }

}
