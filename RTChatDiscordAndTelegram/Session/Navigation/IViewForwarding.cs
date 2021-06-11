using RTChatDiscordAndTelegram.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace RTChatDiscordAndTelegram.Session.Navigation
{
    public enum ViewName
    {
        HomeView,
        DiscordView,
        TelegramView,
        SharedView,
        MainWindow,
        LoginView
    }
    public interface IViewForwarding
    {
        ViewModelBase ActiveViewModel { get; set; }
        event Action StateChanged;
        ViewModelBase ActiveViewLW { get; set; }
        event Action StateChangedLW;
    }
}
