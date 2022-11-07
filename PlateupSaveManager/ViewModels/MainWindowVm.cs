using inpce.core.Library.Extensions;
using PlateupSaveManager.Views;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using SplashScreen = PlateupSaveManager.Views.Splashscreen;

namespace PlateupSaveManager.ViewModels
{
    internal class MainWindowVm : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        Page _currentWindow; public Page CurrentWindow
        {
            get => _currentWindow;
            set => this.SetProperty(ref _currentWindow, value, PropertyChanged);
        }

        public MainWindowVm()
        {
            CurrentWindow = new SplashScreen();
            CurrentWindow = new SaveManager();
        }
    }
}
