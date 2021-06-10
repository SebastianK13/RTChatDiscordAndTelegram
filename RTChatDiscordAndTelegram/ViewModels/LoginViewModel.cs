using RTChatDiscordAndTelegram.Data.Models.Additional;
using RTChatDiscordAndTelegram.Services.Crypto;
using RTChatDiscordAndTelegram.Session.Factory;
using RTChatDiscordAndTelegram.Session.Navigation;
using System;
using System.Collections.Generic;
using System.Text;

namespace RTChatDiscordAndTelegram.ViewModels
{
    public class LoginViewModel: ViewModelBase
    {
        private readonly IViewForwarding _forwarding;
        private readonly IViewModelFactory _viewModelFactory;
        public LoginViewModel(IViewForwarding forwarding, IViewModelFactory viewModelFactory, ContextsContainer contexts)
        {
            _forwarding = forwarding;
            _viewModelFactory = viewModelFactory;
            PasswordService passwordService = new PasswordService();
        }
    }
}
