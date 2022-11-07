using PlateupSaveManager.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlateupSaveManager.Interfaces
{
    internal interface IChangeView
    {
        public event EventHandler<ChangePageEventArgs> ChangePage;
    }
}
