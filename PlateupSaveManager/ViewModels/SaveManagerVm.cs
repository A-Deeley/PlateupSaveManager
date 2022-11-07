using Microsoft.Extensions.Configuration;
using PlateupSaveManager.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlateupSaveManager.ViewModels
{
    internal class SaveManagerVm : IDataContext
    {
        private IConfiguration _configuration;
        public event PropertyChangedEventHandler? PropertyChanged;

        public SaveManagerVm(IConfiguration configuration)
        {
            _configuration = configuration;
        }
    }
}
