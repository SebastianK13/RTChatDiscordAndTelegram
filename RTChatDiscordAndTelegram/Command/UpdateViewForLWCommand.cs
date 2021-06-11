using RTChatDiscordAndTelegram.Session.Factory;
using RTChatDiscordAndTelegram.Session.Navigation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace RTChatDiscordAndTelegram.Command
{
    public class UpdateViewForLWCommand: ICommand
    {
        public event EventHandler CanExecuteChanged;
        private readonly IViewForwarding _forwarding;
        private readonly IViewModelFactory _viewModelFactory;

        public UpdateViewForLWCommand(IViewModelFactory viewModelFactory, IViewForwarding forwarding)
        {
            _forwarding = forwarding;
            _viewModelFactory = viewModelFactory;
        }
        public bool CanExecute(object parameter)
        {
            throw new NotImplementedException();
        }

        public void Execute(object parameter)
        {
            if (parameter is ViewName)
            {
                ViewName view = (ViewName)parameter;
                _forwarding.ActiveViewLW =
                    _viewModelFactory.CreateViewModel(view);
            }
        }
    }
}
