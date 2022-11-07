using Microsoft.Extensions.Configuration;
using PlateupSaveManager.ViewModels;
using PlateupSaveManager.Views;
using System.Windows;

namespace PlateupSaveManager
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            ConfigurationBuilder configBuilder = new();
            var config = configBuilder
                .AddJsonFile(@".\settings.json")
                .Build();

            Window mainWindow = new MainWindow();
            mainWindow.DataContext = new MainWindowVm(config);
            mainWindow.Show();
        }
    }
}
