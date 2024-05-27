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
    /// Interaction logic for CustomerMenu.xaml
    /// </summary>
    public partial class CustomerMenu : Page
    {

        private MenuItem menuItem;
        private User _user;
        public CustomerMenu()
        {
            InitializeComponent();
            menuItem = new MenuItem();
            LoadDataGrid();

        }

        public CustomerMenu(User user)
        {
            InitializeComponent();
            menuItem = new MenuItem();
            LoadDataGrid();
            _user = user;
        }



       
        private void LoadDataGrid()
        {
            try
            {
                List<MenuItem> menuitems = menuItem.LoadItemsFromDatabase();
                UsersDataGrid.ItemsSource = menuitems;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading items: {ex.Message}");
            }
        }


    }
}
