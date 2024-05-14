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

      


       



            private void Border_MouseDown1(object sender, MouseButtonEventArgs e)
            {
            if (e.ChangedButton == MouseButton.Left)
                Window.GetWindow(this).DragMove();
        }

            private void Image_MouseUp(object sender, MouseButtonEventArgs e)
            {
            Application.Current.Shutdown();
        }

            private void PasswordBox_PasswordChanged1(object sender, RoutedEventArgs e)
            {
            if (!string.IsNullOrEmpty(passwordBox1.Password) && passwordBox1.Password.Length > 0)
                textPassword1.Visibility = Visibility.Collapsed;
            else
                textPassword1.Visibility = Visibility.Visible;
        }

            private void textPassword_MouseDown1(object sender, MouseButtonEventArgs e)
            {
            passwordBox1.Focus();
        }

            



            private void txtEmail_TextChanged1(object sender, TextChangedEventArgs e)
            {
            if (!string.IsNullOrEmpty(txtEmail1.Text) && txtEmail1.Text.Length > 0)
                textEmail1.Visibility = Visibility.Collapsed;
            else
                textEmail1.Visibility = Visibility.Visible;
        }

            private void textEmail_MouseDown1(object sender, MouseButtonEventArgs e)
            {
            txtEmail1.Focus();
        }

        private void confirm_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(confpass.Text) && confpass.Text.Length > 0)
                confirmpass.Visibility = Visibility.Collapsed;
            else
                confirmpass.Visibility = Visibility.Visible;
        }

        private void confirm_MouseDown(object sender, MouseButtonEventArgs e)
        {
            confpass.Focus();
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





