using SideBar_Nav.Pages;
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
    /// Interaction logic for Index.xaml
    /// </summary>
    /// 
   
    public partial class Index : Page
    {
        public User _user; 
        public Index()
        {
            InitializeComponent();

            FilterNavItems();
        }
        public Index(User user)
        {
            InitializeComponent();
            _user = user;
            FilterNavItems();
           
            
        }
        private void FilterNavItems()
        {
            sidebar.Items.Clear();
            if (_user.Gettype() == "customer")
            {
                sidebar.Items.Add(new NavButton { Navlink = new Uri("Customerorderpage.xaml", UriKind.Relative), Margin = new Thickness(0, 20, 0, 10), Padding = new Thickness(6), Text = "Order", User = _user });
                sidebar.Items.Add(new NavButton { Navlink = new Uri("Tablepage.xaml", UriKind.Relative), Margin = new Thickness(0, 20, 0, 10), Padding = new Thickness(6), Text = "Tables" });
                sidebar.Items.Add(new NavButton { Navlink = new Uri("Menupage.xaml", UriKind.Relative), Margin = new Thickness(0, 20, 0, 10), Padding = new Thickness(6), Text = "Menu" });
            }
            else if (_user.Gettype() == "admin")
            {
                sidebar.Items.Add(new NavButton { Navlink = new Uri("Page1.xaml", UriKind.Relative), Margin = new Thickness(0, 20, 0, 10), Padding = new Thickness(6), Text = "Order", User = _user });
                sidebar.Items.Add(new NavButton { Navlink = new Uri("Inventorypage.xaml", UriKind.Relative), Margin = new Thickness(0, 20, 0, 10), Text = "Inventory" });
                sidebar.Items.Add(new NavButton { Navlink = new Uri("Tablepage.xaml", UriKind.Relative), Margin = new Thickness(0, 20, 0, 10), Padding = new Thickness(6), Text = "Tables" });
                sidebar.Items.Add(new NavButton { Navlink = new Uri("Menupage.xaml", UriKind.Relative), Margin = new Thickness(0, 20, 0, 10), Padding = new Thickness(6), Text = "Menu" });
            }
        }
        private void sidebar_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selected = sidebar.SelectedItem as NavButton;
            if (selected != null)
            {
              
                if (selected.Navlink.OriginalString == "Page1.xaml" )
                    navframe.Navigate(new Page1(_user));
                else if (selected.Navlink.OriginalString == "Customerorderpage.xaml")
                    navframe.Navigate(new Customerorderpage(_user));
                else
                    navframe.Navigate(selected.Navlink);
            }
        }





    }
}
