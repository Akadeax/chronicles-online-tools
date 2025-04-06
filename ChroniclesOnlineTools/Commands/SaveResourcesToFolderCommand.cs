using ChroniclesOnlineTools.Models;
using ChroniclesOnlineTools.Stores;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ChroniclesOnlineTools.Commands
{
    public class SaveResourcesToFolderCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;
        public bool CanExecute(object? parameter)
        {
            return _resourcesFolderStore.ResourcesFolder != null;
        }

        public void Execute(object? parameter)
        {
            if (_resourcesFolderStore.ResourcesFolder == null)
            {
                Error();
                return;
            }

            FileInfo? itemFile = _resourcesFolderStore.ResourcesFolder!.GetFiles().FirstOrDefault(x => x.Name == "items.json");

            if (itemFile == null)
            {
                Error();
                return;
            }

            ItemDataContainer container = new()
            {
                ArmorSets = [.._resourcesFolderStore.ArmorSets],
                ArmorItems = [.._resourcesFolderStore.ArmorItems],
                WeaponItems = [.._resourcesFolderStore.WeaponItems],
            };

            string jsonText = JsonConvert.SerializeObject(container);
            File.WriteAllText(itemFile.FullName, jsonText);

            MessageBox.Show(
                $"Successfully saved your changes to:\n{itemFile.FullName}",
                "Success!", MessageBoxButton.OK, MessageBoxImage.Information
            );
        }

        private static void Error()
        {
            MessageBox.Show("No valid resource folder is loaded!", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private ResourcesFolderStore _resourcesFolderStore;
        public SaveResourcesToFolderCommand(ResourcesFolderStore store)
        {
            _resourcesFolderStore = store;
            _resourcesFolderStore.PropertyChanged += ResourcesFolderStore_PropertyChanged;
        }

        private void ResourcesFolderStore_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(ResourcesFolderStore.ResourcesFolder))
            {
                CanExecuteChanged?.Invoke(sender, e);
            }
        }
    }
}
