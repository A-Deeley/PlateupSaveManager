using Microsoft.Extensions.Configuration;
using PlateupSaveManager.Events;
using PlateupSaveManager.Interfaces;
using PlateupSaveManager.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlateupSaveManager.ViewModels
{
    internal class DataLoader
    {
        private readonly string _saveFilesLocation;

        internal DataLoader(IConfigurationSection directories)
        {
            string saveManagerFiles = directories.GetValue<string>("saveManagerLocation");
            string localLow = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData).Replace("Roaming", "LocalLow");
            _saveFilesLocation = Path.Combine(localLow, saveManagerFiles);
        }

        internal IEnumerable<SaveFile> LoadFiles()
        {
            if (!Directory.Exists(_saveFilesLocation))
                Directory.CreateDirectory(_saveFilesLocation);

            var listOfFiles =
                Directory.GetDirectories(_saveFilesLocation)
                .Select(Path.GetFileName)
                .ToList();

            List<SaveFile> saveFiles = new List<SaveFile>();

            foreach (var file in listOfFiles)
                if (file is not null)
                    saveFiles.Add(new(file));

            return saveFiles;
        }
    }
}
