using System;
using System.Collections.Generic;
using System.Text;
using RTChatDiscordAndTelegram.Models;
using RTChatDiscordAndTelegram.Session.Navigation;
using RTChatDiscordAndTelegram.ViewModels;

namespace RTChatDiscordAndTelegram.Session.Factory
{
    public class ViewModelFactory : ViewModelsContainer, IViewModelFactory
    {
        private readonly ViewModelsContainer _viewModelInstances;
        public ViewModelFactory(ViewModelsContainer viewModelInstances) =>
            _viewModelInstances = viewModelInstances;

        public ViewModelBase CreateViewModel(ViewName viewName)
        {
            switch (viewName)
            {
                case ViewName.HomeView:
                    return _viewModelInstances.CreateHomeVM();
                case ViewName.DiscordView:
                    return _viewModelInstances.CreateDiscordVM();
                case ViewName.TelegramView:
                    return _viewModelInstances.CreateTelegramVM();
                case ViewName.SharedView:
                    return _viewModelInstances.CreateSharedVM();
                case ViewName.LoginView:
                    return _viewModelInstances.CreateLoginVM();
                default:
                    throw new ArgumentException("The ViewName does not have a ViewModel.", "viewName");
            }
        }
    }
}
