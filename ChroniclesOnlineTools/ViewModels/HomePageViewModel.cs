using ChroniclesOnlineTools.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ChroniclesOnlineTools.ViewModels
{
    public class HomePageViewModel : ViewModelBase
    {
        private readonly MainViewModel _mainViewModel;

        public ICommand NavigateItemManagerCommand { get; }
        public ICommand NavigateSkillTreeEditorCommand { get; }

        public HomePageViewModel(MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;

            NavigateItemManagerCommand = new NavigateCommand(_mainViewModel, () => new ItemManagerViewModel(_mainViewModel));
            NavigateSkillTreeEditorCommand = new NavigateCommand(_mainViewModel, () => new SkillTreeEditorViewModel());
        }
    }
}
