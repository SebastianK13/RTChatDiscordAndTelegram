using RTChatDiscordAndTelegram.Command;
using RTChatDiscordAndTelegram.Data.Models.Additional;
using RTChatDiscordAndTelegram.Services.Containers;
using RTChatDiscordAndTelegram.Session.Factory;
using RTChatDiscordAndTelegram.Session.Navigation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace RTChatDiscordAndTelegram.ViewModels
{
    public class LoginViewModel: ViewModelBase
    {
        private string _username;
        private string _errorDesc;
        private bool _errVisibility;
        private readonly IViewForwarding _forwarding;

        public string ErrorDesc 
        {
            get => _errorDesc;
            set 
            {
                _errorDesc = value;
                OnPropertyChanged("ErrorDesc");
            }
        }
        public string Username
        {
            get => _username;
            set
            {
                _username = value;
                OnPropertyChanged("Username");
            }
        }
        public bool ErrorVisibility
        {
            get => _errVisibility;
            set
            {
                _errVisibility = value;
                OnPropertyChanged("ErrorVisibility");
            }
        }
        public ICommand SignUpCommand { get; }
        public ICommand LoginCommand { get; }
        public ICommand UpdateViewModel { get; }
        public LoginViewModel(InterfacesContainer container, ContextsContainer contexts)
        {
            _forwarding = container.Forwarding;
            LoginCommand = new LoginCommand(contexts.Identity, this, container.Authorization);
            SignUpCommand = new SignUpCommand(contexts.Identity, this, container.Authorization);
            UpdateViewModel = new UpdateViewModelCommand(container.ViewModelFactory, container.Forwarding);
        }

        public void ChangeLoginState(bool stateValue) =>
            _forwarding.IsLoginActive = stateValue;
    }
}
