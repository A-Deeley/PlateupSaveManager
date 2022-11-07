using Microsoft.Extensions.Configuration;
using PlateupSaveManager.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlateupSaveManager.ViewModels
{
    internal class DataLoaderVm : IDataContext
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        public DataLoaderVm(IConfigurationSection directories)
        {
            string saveManagerFiles = directories.GetValue<string>("saveManagerLocation");
            string localLow = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData).Replace("Roaming", "LocalLow");
            string saveFilesLocation = Path.Combine(localLow, saveManagerFiles);

            if (!Directory.Exists(saveFilesLocation))
                Directory.CreateDirectory(saveFilesLocation);

            var listOfFiles =
                Directory.GetDirectories(saveFilesLocation)
                .Select(Path.GetFileName)
                .ToList();

            List<SaveFile> saveFiles = new List<SaveFile>();

            foreach (var file in listOfFiles)
                if (file is not null)
                    saveFiles.Add(new(file));
        }
    }
}
