using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
    /// Interaction logic for Page5.xaml
    /// </summary>
    public partial class Page5 : Page
    {
        public Page5()
        {
            InitializeComponent();
        }

      


       



            private void Border_MouseDown(object sender, MouseButtonEventArgs e)
            {
            if (e.ChangedButton == MouseButton.Left)
                Window.GetWindow(this).DragMove();
        }

            private void Image_MouseUp(object sender, MouseButtonEventArgs e)
            {
            Application.Current.Shutdown();
        }

            private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
            {
            if (!string.IsNullOrEmpty(passwordBox.Password) && passwordBox.Password.Length > 0)
                textPassword.Visibility = Visibility.Collapsed;
            else
                textPassword.Visibility = Visibility.Visible;
        }

            private void textPassword_MouseDown(object sender, MouseButtonEventArgs e)
            {
            passwordBox.Focus();
        }

            



            private void txtEmail_TextChanged(object sender, TextChangedEventArgs e)
            {
            if (!string.IsNullOrEmpty(txtEmail.Text) && txtEmail.Text.Length > 0)
                textEmail.Visibility = Visibility.Collapsed;
            else
                textEmail.Visibility = Visibility.Visible;
        }

            private void textEmail_MouseDown(object sender, MouseButtonEventArgs e)
            {
            txtEmail.Focus();
        }

           

        private void signup(object sender, RoutedEventArgs e)
        {
             NavigationService.Navigate(new Index());


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
             NavigationService.Navigate(new Signin());
        }
    }
    }





