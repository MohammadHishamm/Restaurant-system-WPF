using System.Configuration;
using System.Data;
using System.Windows;

namespace program
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            //StartupUri = new Uri("Signin.xaml", UriKind.Relative);
        }
    }

}
