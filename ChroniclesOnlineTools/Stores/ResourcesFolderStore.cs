using ChroniclesOnlineTools.Models;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;

namespace ChroniclesOnlineTools.Stores
{
    public class ResourcesFolderStore : INotifyPropertyChanged
    {
        public DirectoryInfo? ResourcesFolder { get; private set; }

        public ObservableCollection<ArmorSet> ArmorSets { get; set; } = [];
        public ObservableCollection<ArmorItem> ArmorItems { get; set; } = [];
        public ObservableCollection<WeaponItem> WeaponItems { get; set; } = [];
        public string? ResourcesFolderPath { get; set; }
        /// <summary>
        /// Attempts to data from the given folder
        /// </summary>
        /// <param name="folderPath"></param>
        /// <exception cref="FileNotFoundException"></exception>
        /// <exception cref="JsonException"></exception>
        public void SetFolder(string folderPath)
        {
            if (string.IsNullOrEmpty(folderPath))
            {
                throw new FileNotFoundException("Folder path is empty!");
            }

            DirectoryInfo folder = new DirectoryInfo(folderPath);
            if (folder.GetFiles().All(x => x.Name != "items.json"))
            {
                throw new FileNotFoundException("No item file found in resource folder!");
            }

            FileInfo itemsFile = folder.GetFiles().First(x => x.Name == "items.json");
            string itemsJsonString = File.ReadAllText(itemsFile.FullName);

            ItemDataContainer? data = JsonConvert.DeserializeObject<ItemDataContainer>(itemsJsonString);

            ArmorSets = new ObservableCollection<ArmorSet>(data?.ArmorSets ?? []);
            OnPropertyChanged(nameof(ArmorSets));
            ArmorItems = new ObservableCollection<ArmorItem>(data?.ArmorItems ?? []);
            OnPropertyChanged(nameof(ArmorItems));
            WeaponItems = new ObservableCollection<WeaponItem>(data?.WeaponItems ?? []);
            OnPropertyChanged(nameof(WeaponItems));

            ResourcesFolder = folder;
            OnPropertyChanged(nameof(ResourcesFolder));
            ResourcesFolderPath = ResourcesFolder.FullName;
            OnPropertyChanged(nameof(ResourcesFolderPath));
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
