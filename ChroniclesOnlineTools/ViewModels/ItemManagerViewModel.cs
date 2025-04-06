using ChroniclesOnlineTools.Commands;
using ChroniclesOnlineTools.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;
using ChroniclesOnlineTools.Stores;

namespace ChroniclesOnlineTools.ViewModels
{
    public class ItemManagerViewModel : ViewModelBase
    {
        private object? _itemToEdit;
        public object? ItemToEdit 
        {
            get => _itemToEdit;
            set
            {
                _itemToEdit = value;
                OnPropertyChanged(nameof(ItemToEdit));
            }
        }

        public ObservableCollection<ArmorSet> ArmorSets => _resourcesFolderStore.ArmorSets;
        public ObservableCollection<ArmorItem> ArmorItems => _resourcesFolderStore.ArmorItems;
        public ObservableCollection<WeaponItem> WeaponItems => _resourcesFolderStore.WeaponItems;
        public string? ResourcesFolderPath => _resourcesFolderStore.ResourcesFolderPath;

        private readonly ResourcesFolderStore _resourcesFolderStore;

        public ICommand SetResourcesFolderCommand { get; }
        public ICommand SaveChangesCommand { get; }

        public ICommand ChangeItemToEditCommand { get; }
        public ICommand DeleteItemCommand { get; }

        private MainViewModel _mainViewModel;

        public ItemManagerViewModel(MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;


            ChangeItemToEditCommand = new ChangeItemToEditCommand(this);
            DeleteItemCommand = new DeleteItemCommand(this);

            _resourcesFolderStore = new ResourcesFolderStore();
            // Mirror property changed; ResourcesFolderStore has its own properties that are
            // updated, and this informs the bindings to *this* object
            _resourcesFolderStore.PropertyChanged += (s, e) =>
            {
                OnPropertyChanged(e.PropertyName);
            };

            SetResourcesFolderCommand setResourcesFolderCommand = new SetResourcesFolderCommand(_resourcesFolderStore);
            setResourcesFolderCommand.NewResourcesSet += SetResourcesFolderCommand_NewResourcesSet;
            SetResourcesFolderCommand = setResourcesFolderCommand;

            SaveChangesCommand = new SaveResourcesToFolderCommand(_resourcesFolderStore);
        }

        private void SetResourcesFolderCommand_NewResourcesSet(object? sender, EventArgs e)
        {
            ItemToEdit = null;
        }
    }
}
