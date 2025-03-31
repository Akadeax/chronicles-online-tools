using ChroniclesOnlineTools.Commands;
using ChroniclesOnlineTools.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ChroniclesOnlineTools.ViewModels
{
    public class ItemManagerViewModel : ViewModelBase
    {
        public ObservableCollection<ArmorSet> ArmorSets { get; set; } = [];
        public ObservableCollection<ArmorItem> ArmorItems { get; set; } = [];
        public ObservableCollection<WeaponItem> WeaponItems { get; set; } = [];

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

        public ICommand ChangeItemToEditCommand { get; }
        public ICommand DeleteItemCommand { get; }

        private MainViewModel _mainViewModel;

        public ItemManagerViewModel(MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;

            ChangeItemToEditCommand = new ChangeItemToEditCommand(this);
            DeleteItemCommand = new DeleteItemCommand(this);

            ArmorSets.Add(
                new ArmorSet
                {
                    Id = "leather",
                    Name = "Leather Armor Set",
                    EffectDescription = "Makes you stylish in full leather"
                }
            );
            ArmorSets.Add(
                new ArmorSet
                {
                    Id = "steel",
                    Name = "Steel Armor Set",
                    EffectDescription = "Makes you stylish in full steel"
                }
            );

            WeaponItems.Add(
                new WeaponItem
                {
                    Id = "iron_sword",
                    Name = "Iron Sword",
                    AttackPower = 24
                }
            );
        }
    }
}
