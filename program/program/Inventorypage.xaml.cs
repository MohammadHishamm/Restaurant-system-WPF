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
             
                inventory.LoadItemsFromDatabase();

              
                UsersDataGrid.ItemsSource = inventory.inventoryItems;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading items: {ex.Message}");
            }
        }
        private void editItem_Click(object sender, RoutedEventArgs e)
        {
         
            var selectedItem = UsersDataGrid.SelectedItem;

       
            if (selectedItem != null)
            {
               
                string itemName = ((KeyValuePair<string, int>)selectedItem).Key;

               
                Updateinventoryitem updateWindow = new Updateinventoryitem(itemName);
                updateWindow.ShowDialog(); 
            }
            else
            {
                MessageBox.Show("Please select an item to edit.");
            }
        }
        private void deleteitem_click(object sender, RoutedEventArgs e)
        {
           
            var selectedItem = UsersDataGrid.SelectedItem;

      
            if (selectedItem != null)
            {
                
                string itemName = ((KeyValuePair<string, int>)selectedItem).Key;

               
                Inventory inventory = new Inventory();

              
                inventory.DeleteItemFromDatabase(itemName);
                MessageBox.Show("Item added successfully.");
            }
            else
            {
                MessageBox.Show("Please select an item to delete.");
            }
        }


    }




}


