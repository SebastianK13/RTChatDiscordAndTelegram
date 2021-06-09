using RTChatDiscordAndTelegram.Session.Factory;
using RTChatDiscordAndTelegram.Session.Navigation;
using System;
using System.Collections.Generic;
using System.Text;

namespace RTChatDiscordAndTelegram.ViewModels
{
    public class DiscordViewModel: ViewModelBase
    {
        private readonly IViewForwarding _forwarding;
        private readonly IViewModelFactory _viewModelFactory;
        public DiscordViewModel(IViewForwarding forwarding, IViewModelFactory viewModelFactory)
        {
            _forwarding = forwarding;
            _viewModelFactory = viewModelFactory;
        }
    }
}
