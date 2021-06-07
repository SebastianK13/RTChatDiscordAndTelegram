using RTChatDiscordAndTelegram.Session.Factory;
using RTChatDiscordAndTelegram.Session.Navigation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RTChatDiscordAndTelegram.Command
{
    public class UpdateViewModelCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private readonly IViewForwarding _forwarding;
        private readonly IViewModelFactory _viewModelFactory;

        public UpdateViewModelCommand(IViewModelFactory viewModelFactory, IViewForwarding forwarding)
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
            if(parameter is ViewName)
            {
                ViewName view = (ViewName)parameter;
                _forwarding.ActiveViewModel = 
                    _viewModelFactory.CreateViewModel(view);
            }
        }
    }
}
