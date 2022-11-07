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

        string _name; public string Name
        {
            get => _name;
            set => this.SetProperty(ref _name, value, PropertyChanged);
        }

        public SaveFile()
        {

        }

        public SaveFile(string name)
        {
            Name = name;
        }
    }
}
