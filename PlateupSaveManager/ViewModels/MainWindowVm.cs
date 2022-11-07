using inpce.core.Library.Extensions;
using Microsoft.Extensions.Configuration;
using PlateupSaveManager.Extensions;
using PlateupSaveManager.Interfaces;
using PlateupSaveManager.Views;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

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
            LoadData();
        }

        private void LoadData()
        {
            var loader = new DataLoader(_configuration.GetSection("directories"));
            var files = loader.LoadFiles();
            CurrentWindow = CreateSaveManager(files);
        }

        private void Context_ChangePage(object? sender, Events.ChangePageEventArgs e)
        {
            if (!e.NewPage.IsOfType<SaveManager>())
                return;

            if (e.Data is not IEnumerable<SaveFile>)
                return;

            var saveFiles = e.Data.ToEnumerable<SaveFile>();
            CurrentWindow = CreateSaveManager(saveFiles);
        }

        private SaveManager CreateSaveManager(IEnumerable<SaveFile> saveFiles)
        {
            var saveManager = new SaveManager();
            var context = new SaveManagerVm(_configuration.GetSection("directories"), saveFiles);
            return saveManager.SetDataContext(context);
        }
    }
}
