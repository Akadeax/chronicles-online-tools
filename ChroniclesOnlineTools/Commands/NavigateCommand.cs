using ChroniclesOnlineTools.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ChroniclesOnlineTools.Commands
{
    public class NavigateCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;
        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            _mainViewModel.Navigate(_makeTarget());
        }

        MainViewModel _mainViewModel;
        Func<ViewModelBase> _makeTarget;

        public NavigateCommand(MainViewModel mainViewModel, Func<ViewModelBase> makeTarget)
        {
            _mainViewModel = mainViewModel;
            _makeTarget = makeTarget;
        }
    }
}
