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
        private bool _errVisibility;

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
        public ICommand LoginCommand { get; } 
        public ICommand UpdateViewModel { get; }
        public LoginViewModel(InterfacesContainer container, ContextsContainer contexts)
        {
            LoginCommand = new LoginCommand(contexts.Identity, this, container.Authorization);
            UpdateViewModel = new UpdateViewModelCommand(container.ViewModelFactory, container.Forwarding);
        }
    }
}
