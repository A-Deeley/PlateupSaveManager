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

        SaveFile? _currentSave; public string CurrentSaveName
        {
            get => SaveFiles.FirstOrDefault(file => file.IsActive, null)?.Name ?? "Unsaved game";
        }

        ObservableCollection<SaveFile> _saveFiles; public ObservableCollection<SaveFile> SaveFiles
        {
            get => _saveFiles;
            set => this.SetProperty(ref _saveFiles, value, PropertyChanged);
        }

        SaveFile _selectedSave; public SaveFile SelectedSave
        {
            get => _selectedSave;
            set => this.SetProperty(ref _selectedSave, value, PropertyChanged);
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        public event EventHandler<ChangePageEventArgs> ChangePage;

        #region ICommands
        public RelayCommand Save { get; set; }
        public RelayCommand NewSave { get; set; }
        public RelayCommand ActivateSelectedSave { get; set; }
        public RelayCommand DeactivateSelectedSave { get; set; }
        public RelayCommand RenameSelectedSave { get; set; }
        public RelayCommand DeleteSelectedSave { get; set; }

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
            return _currentSave is null;
        }

        private bool NewSave_CanExecute(object _)
        {
            return true;
        }

        private bool IsSaveSelected(object _) => SelectedSave is not null;
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
            ActivateSelectedSave = new(Activate_Execute, IsSaveSelected);
            DeactivateSelectedSave = new(Deactivate_Execute, IsSaveSelected);
            RenameSelectedSave = new(Rename_Execute, IsSaveSelected);
            DeleteSelectedSave = new(Delete_Execute, IsSaveSelected);
        }
    }
}
