using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace PlateupSaveManager.Events
{
    internal class ChangePageEventArgs : EventArgs
    {
        public Page NewPage { get; init; }
        public object? Data { get; init; }
        public ChangePageEventArgs(Page newPage, object data)
        {
            NewPage = newPage;
            Data = data;
        }

        public ChangePageEventArgs() { }
    }
}
