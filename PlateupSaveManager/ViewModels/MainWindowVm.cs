using inpce.core.Library.Extensions;
using Microsoft.Extensions.Configuration;
using PlateupSaveManager.Extensions;
using PlateupSaveManager.Interfaces;
using PlateupSaveManager.Views;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using SplashScreen = PlateupSaveManager.Views.Splashscreen;

namespace PlateupSaveManager.ViewModels
{
    internal class MainWindowVm : IDataContext
    {
        private IConfiguration _configuration;
        public event PropertyChangedEventHandler? PropertyChanged;

        Page _currentWindow; public Page CurrentWindow
        {
            get => _currentWindow;
            set => this.SetProperty(ref _currentWindow, value, PropertyChanged);
        }

        public MainWindowVm(IConfiguration configuration)
        {
            _configuration = configuration;
            CurrentWindow = new SplashScreen();
            CurrentWindow = CreateSaveManager();
        }

        private SaveManager CreateSaveManager()
        {
            var saveManager = new SaveManager();
            var context = new SaveManagerVm(_configuration);
            return saveManager.SetDataContext(context);
        }
    }
}
