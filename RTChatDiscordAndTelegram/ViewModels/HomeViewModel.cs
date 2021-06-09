using RTChatDiscordAndTelegram.Session.Factory;
using RTChatDiscordAndTelegram.Session.Navigation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace RTChatDiscordAndTelegram.ViewModels
{
    public class HomeViewModel: ViewModelBase
    {
        private readonly IViewForwarding _forwarding;
        private readonly IViewModelFactory _viewModelFactory;
        public ViewModelBase ActiveViewModel =>
            _forwarding.ActiveViewModel;
        public ICommand UpdateViewModel { get; }
        public HomeViewModel(IViewForwarding forwarding, IViewModelFactory viewModelFactory)
        {
            _forwarding = forwarding;
            _viewModelFactory = viewModelFactory;
        }
        public void Forwarding() =>
            OnPropertyChanged(nameof(ActiveViewModel));
    }
}
