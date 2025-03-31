using ChroniclesOnlineTools.Models;
using ChroniclesOnlineTools.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ChroniclesOnlineTools.Commands
{
    class DeleteItemCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;
        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            switch (parameter)
            {
                case ArmorSet armorSet:
                    _viewModel.ArmorSets.Remove(armorSet);
                    break;
                case ArmorItem armorItem:
                    _viewModel.ArmorItems.Remove(armorItem);
                    break;
                case WeaponItem weaponItem:
                    _viewModel.WeaponItems.Remove(weaponItem);
                    break;
            }
        }

        ItemManagerViewModel _viewModel;

        public DeleteItemCommand(ItemManagerViewModel viewModel)
        {
            _viewModel = viewModel;
        }
    }
}
