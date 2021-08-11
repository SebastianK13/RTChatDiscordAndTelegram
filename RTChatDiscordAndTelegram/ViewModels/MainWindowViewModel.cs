using RTChatDiscordAndTelegram.Command;
using RTChatDiscordAndTelegram.Services.Containers;
using RTChatDiscordAndTelegram.Session.Authorization;
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
        private readonly IAuthorization _authorization;
        private bool mainWindowVisibility;
        public event EventHandler OnCloseDemand;
        private bool beforeLogin = true;

        public ViewModelBase ActiveViewModel => 
            _forwarding.ActiveViewModel;
        public ViewModelBase ActiveViewLoginWindow =>
            _forwarding.ActiveViewLW;
        public ICommand UpdateViewModel { get; }
        public ICommand UpdateLoginWindow { get; }
        public bool MainWindowVisibility 
        {
            get => mainWindowVisibility;
            set
            {
                mainWindowVisibility = value;
                OnPropertyChanged("MainWindowVisibility");
            }
        }
        public MainWindowViewModel(InterfacesContainer container)
        {
            MainWindowVisibility = false;
            _authorization = container.Authorization;
            _forwarding = container.Forwarding;
            _viewModelFactory = container.ViewModelFactory;
            _forwarding.StateChanged += Forwarding;
            _forwarding.StateChangedLW += ForwardViewForLW;
            _forwarding.StateChangedLogin += IsUserLogged;
            UpdateViewModel = new UpdateViewModelCommand(_viewModelFactory, _forwarding);
            UpdateLoginWindow = new UpdateViewForLWCommand(_viewModelFactory, _forwarding);
            UpdateLoginWindow.Execute(ViewName.LoginView);
        }
        public void Forwarding() =>
            OnPropertyChanged(nameof(ActiveViewModel));
        public void ForwardViewForLW() =>
            OnPropertyChanged(nameof(ActiveViewLoginWindow));
        public bool IsLogged() =>
            _authorization.IsLogged;
        public void CloseOnSuccefull() =>
            OnCloseDemand(this, new EventArgs());
        public void IsUserLogged() =>
            CloseOnSuccefull();
    }
}
