using RTChatDiscordAndTelegram.Session.Navigation;
using RTChatDiscordAndTelegram.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace RTChatDiscordAndTelegram.Session.Factory
{
    public interface IViewModelFactory
    {
        ViewModelBase CreateViewModel(ViewName viewName);
    }
}
