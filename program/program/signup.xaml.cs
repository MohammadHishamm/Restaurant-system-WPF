using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

        private void confirm_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(confpass.Password) && confpass.Password.Length > 0)
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
            Encryption encryption = new Encryption();
            

            if (confpass.Password == passwordBox1.Password && !string.IsNullOrEmpty(passwordBox1.Password) && passwordBox1.Password.Length >= 7 && IsValidEmail(txtEmail1.Text))
            {
                
                DBconfig db = new DBconfig();
                db.OpenConnection();
                string query = $"INSERT INTO [user] (email,password, type) VALUES (@Email, @Password,@type)";
                SqlCommand command = new SqlCommand(query, db.GetConn());
                command.Parameters.AddWithValue("@Email", txtEmail1.Text);
                command.Parameters.AddWithValue("@Password", encryption.Encrypt(passwordBox1.Password));
                command.Parameters.AddWithValue("@type", "customer");
                command.ExecuteNonQuery();

                db.CloseConnection();

                NavigationService.Navigate(new Index());
            }
            else
            {
                MessageBox.Show("Error occurred!\n\nPlease ensure that:\n- Email is in the correct format.\n- Password is at least 7 characters long.\n- Confirm password matches the password entered.\n- No empty data is allowed.");
            }


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
             NavigationService.Navigate(new Signin());
        }


        private bool IsValidEmail(string email)
        {
            // Regex pattern for email validation
            string pattern = @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$";
            Regex regex = new Regex(pattern);
            return regex.IsMatch(email);
        }

    }
    }





