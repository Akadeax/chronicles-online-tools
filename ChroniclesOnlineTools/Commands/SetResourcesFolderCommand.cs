using ChroniclesOnlineTools.Stores;
using Microsoft.WindowsAPICodePack.Dialogs;
using System.Windows;
using System.Windows.Input;
using Newtonsoft.Json;

namespace ChroniclesOnlineTools.Commands
{
    public class SetResourcesFolderCommand : ICommand
    {
        public event EventHandler? NewResourcesSet;

        public event EventHandler? CanExecuteChanged;
        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            CommonOpenFileDialog dialog = new();
            dialog.IsFolderPicker = true;

            if (dialog.ShowDialog() != CommonFileDialogResult.Ok)
            {
                MessageBox.Show("You must select a valid Resource folder!", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            try
            {
                _resourcesFolderStore.SetFolder(dialog.FileName!);
            }
            catch (JsonException e)
            {
                MessageBox.Show($"Your JSON might be invalid:\n{e.Message}", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            NewResourcesSet?.Invoke(this, EventArgs.Empty);
        }

        private ResourcesFolderStore _resourcesFolderStore;
        public SetResourcesFolderCommand(ResourcesFolderStore store)
        {
            _resourcesFolderStore = store;
        }
    }
}
