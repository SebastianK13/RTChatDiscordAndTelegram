using RTChatDiscordAndTelegram.Session.Factory;
using RTChatDiscordAndTelegram.Session.Navigation;
using RTChatDiscordAndTelegram.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RTChatDiscordAndTelegram.Command
{
    public class ChooseManagePanel : ICommand
    {
        private readonly HomeViewModel _homeViewModel;
        private readonly IViewModelFactory _viewModelFactory;

        public ChooseManagePanel(HomeViewModel homeViewModel, IViewModelFactory viewModelFactory)
        {
            _homeViewModel = homeViewModel;
            _viewModelFactory = viewModelFactory;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter) => true;

        public void Execute(object parameter)
        {
            ViewName view;
            bool success = Enum.TryParse(parameter.ToString(), out view);
            if (success)
            {
                _homeViewModel.ManagePanel =
                    _viewModelFactory.CreateViewModel(view);
            }
        }
    }
}
