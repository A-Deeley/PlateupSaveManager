using PlateupSaveManager.ViewModels;
using PlateupSaveManager.Views;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
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
            Window mainWindow = new MainWindow();
            mainWindow.DataContext = new MainWindowVm();
            mainWindow.Show();
        }
    }
}
