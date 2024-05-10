using System.Windows;
using program;

namespace program
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // Navigate to the login page when the MainWindow is loaded
            NavigateToLoginPage();
        }

        // Method to navigate to the login page
        private void NavigateToLoginPage()
        {
            MainFrame.Navigate(new Login());
        }
    }
}
