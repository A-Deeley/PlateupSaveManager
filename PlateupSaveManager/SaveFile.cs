using inpce.core.Library.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlateupSaveManager
{
    internal class SaveFile : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        bool _isActive; public bool IsActive
        {
            get => _isActive;
            set => this.SetProperty(ref _isActive, value, PropertyChanged);
        }
        string _name; public string Name
        {
            get => _name;
            set => this.SetProperty(ref _name, value, PropertyChanged);
        }

        public SaveFile(string name)
            :base()
        {
            IsActive = name.EndsWith("_current");
            Name = name.Split("_")[0];

        }
    }
}
