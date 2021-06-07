using RTChatDiscordAndTelegram.Command;
using RTChatDiscordAndTelegram.Session.Factory;
using RTChatDiscordAndTelegram.Session.Navigation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace RTChatDiscordAndTelegram.ViewModels
{
    public class MainWindowViewModel:ViewModelBase
    {
        private readonly IViewForwarding _forwarding;
        private readonly IViewModelFactory _viewModelFactory;
        public ViewModelBase ActiveViewModel => 
            _forwarding.ActiveViewModel;
        public ICommand UpdateViewModel { get; }
        public MainWindowViewModel(IViewForwarding forwarding, IViewModelFactory viewModelFactory)
        {
            _forwarding = forwarding;
            _viewModelFactory = viewModelFactory;
            _forwarding.StateChanged += Forwarding;
            UpdateViewModel = new UpdateViewModelCommand(viewModelFactory, forwarding);
            UpdateViewModel.Execute(ViewName.HomeView);
        }
        public void Forwarding() =>
            OnPropertyChanged(nameof(ActiveViewModel));
    }
}
