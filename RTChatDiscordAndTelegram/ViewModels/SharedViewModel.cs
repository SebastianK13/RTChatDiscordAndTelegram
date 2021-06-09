using RTChatDiscordAndTelegram.Session.Factory;
using RTChatDiscordAndTelegram.Session.Navigation;
using System;
using System.Collections.Generic;
using System.Text;

namespace RTChatDiscordAndTelegram.ViewModels
{
    public class SharedViewModel: ViewModelBase
    {
        private readonly IViewForwarding _forwarding;
        private readonly IViewModelFactory _viewModelFactory;
        public SharedViewModel(IViewForwarding forwarding, IViewModelFactory viewModelFactory)
        {
            _forwarding = forwarding;
            _viewModelFactory = viewModelFactory;
        }
    }
}
