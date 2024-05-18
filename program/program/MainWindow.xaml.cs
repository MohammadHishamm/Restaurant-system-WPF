using System.Windows;
using program;

namespace program
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            NavigateToSigninPage();


        }

  
        private void NavigateToSigninPage()
        {
            MainFrame.Navigate(new Index());
        }

        private void MainFrame_Navigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {
          
        }


    



    }
}
