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
    /// Interaction logic for Menupage.xaml
    /// </summary>
    public partial class Menupage : Page
    {
        private MenuItem menuItem;
        private User _user;
        public Menupage()
        {
            InitializeComponent();
            menuItem = new MenuItem();
            LoadDataGrid();
        }
        public Menupage(User user)
        {
            InitializeComponent();
            menuItem = new MenuItem();
            LoadDataGrid();
            _user = user;
        }

        private void AddNewItem_Click(object sender, RoutedEventArgs e)
        {
            AddMenuItem addItemWindow = new AddMenuItem();
            addItemWindow.ShowDialog();
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
