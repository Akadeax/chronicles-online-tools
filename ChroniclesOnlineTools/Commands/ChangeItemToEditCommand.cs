using ChroniclesOnlineTools.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ChroniclesOnlineTools.Commands
{
    public class ChangeItemToEditCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;
        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            _viewModel.ItemToEdit = parameter;
        }

        ItemManagerViewModel _viewModel;

        public ChangeItemToEditCommand(ItemManagerViewModel viewModel)
        {
            _viewModel = viewModel;
        }
    }
}
