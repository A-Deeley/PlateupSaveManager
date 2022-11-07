using inpce.core.Library.Extensions;
using Microsoft.Extensions.Configuration;
using PlateupSaveManager.Events;
using PlateupSaveManager.Extensions;
using PlateupSaveManager.Interfaces;
using RelayCommandLibrary;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PlateupSaveManager.ViewModels
{
    internal class SaveManagerVm : IDataContext, IChangeView
    {
        private readonly string localLowPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData).Replace("Roaming", "LocalLow");
        string _relativeSaveManagerDir; public string SaveManagerDir
        {
            get => Path.Combine(localLowPath, _relativeSaveManagerDir);
            set => this.SetProperty(ref _relativeSaveManagerDir, value, PropertyChanged);
        }

        string _relativePlateupSaveDir; public string PlateupSaveDir
        {
            get => Path.Combine(localLowPath, _relativePlateupSaveDir);
            set => this.SetProperty(ref _relativePlateupSaveDir, value, PropertyChanged);
        }

        string _saveName; public string SaveName
        {
            get => _saveName;
            set => this.SetProperty(ref _saveName, value, PropertyChanged);
        }

        ObservableCollection<SaveFile> _saveFiles; public ObservableCollection<SaveFile> SaveFiles
        {
            get => _saveFiles;
            set => this.SetProperty(ref _saveFiles, value, PropertyChanged);
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        public event EventHandler<ChangePageEventArgs> ChangePage;

        #region ICommands
        RelayCommand Save { get; set; }
        RelayCommand NewSave { get; set; }
        RelayCommand ActivateSelectedSave { get; set; }
        RelayCommand DeactivateSelectedSave { get; set; }
        RelayCommand RenameSelectedSave { get; set; }
        RelayCommand DeleteSelectedSave { get; set; }

        #region Executes
        private void Save_Execute(object _)
        {

        }

        private void NewSave_Execute(object _)
        {

        }

        private void Activate_Execute(object _)
        {

        }

        private void Deactivate_Execute(object _)
        {

        }

        private void Rename_Execute(object _)
        {

        }

        private void Delete_Execute(object _)
        {

        }
        #endregion
        #region CanExecutes
        private bool Save_CanExecute(object _)
        {
            return true;
        }

        private bool NewSave_CanExecute(object _)
        {
            return true;
        }

        private bool Activate_CanExecute(object _)
        {
            return true;
        }

        private bool Deactivate_CanExecute(object _)
        {
            return true;
        }

        private bool Rename_CanExecute(object _)
        {
            return true;
        }

        private bool Delete_CanExecute(object _)
        {
            return true;
        }
        #endregion

        #endregion

        public SaveManagerVm(IConfigurationSection directories, IEnumerable<SaveFile> saves)
        {
            ConfigureRelayCommands();
            SaveFiles = saves.ConvertToObservable();
            _relativeSaveManagerDir = directories.GetValue<string>("saveManagerLocation");
            _relativePlateupSaveDir = directories.GetValue<string>("plateupSaveFileLocation");
        }

        private void ConfigureRelayCommands()
        {
            Save = new(Save_Execute, Save_CanExecute);
            NewSave = new(NewSave_Execute);
            ActivateSelectedSave = new(Activate_Execute, Activate_CanExecute);
            DeactivateSelectedSave = new(Deactivate_Execute, Deactivate_CanExecute);
            RenameSelectedSave = new(Rename_Execute, Rename_CanExecute);
            DeleteSelectedSave = new(Delete_Execute, Delete_CanExecute);
        }
    }
}
