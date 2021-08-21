using RTChatDiscordAndTelegram.Command;
using RTChatDiscordAndTelegram.Data.Models;
using RTChatDiscordAndTelegram.Session.Factory;
using RTChatDiscordAndTelegram.Session.Navigation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace RTChatDiscordAndTelegram.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        private readonly IViewForwarding _forwarding;
        private readonly IViewModelFactory _viewModelFactory;
        private object _managePanel;

        public ViewModelBase ActiveViewModel =>
            _forwarding.ActiveViewModel;
        public ICommand UpdateViewModel { get; }
        public ICommand ChooseManagePanel { get; }
        public object ManagePanel
        {
            get
            {
                return _managePanel;
            }
            set
            {
                _managePanel = value;
                OnPropertyChanged("ManagePanel");
            }
        }
        public HomeViewModel(IViewForwarding forwarding, IViewModelFactory viewModelFactory)
        {
            _forwarding = forwarding;
            _viewModelFactory = viewModelFactory;
            ChooseManagePanel = new ChooseManagePanel(this, _viewModelFactory);
        }
        public void Forwarding() =>
            OnPropertyChanged(nameof(ActiveViewModel));
    }
}
