using RTChatDiscordAndTelegram.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using static RTChatDiscordAndTelegram.ViewModels.ViewModelBase;

namespace RTChatDiscordAndTelegram.Models
{
    public class ViewModelsContainer
    {
        public CreateViewModel<LoginViewModel> CreateLoginVM;
        public CreateViewModel<DiscordViewModel> CreateDiscordVM;
        public CreateViewModel<TelegramViewModel> CreateTelegramVM;
        public CreateViewModel<SharedViewModel> CreateSharedVM;
        public CreateViewModel<HomeViewModel> CreateHomeVM;
    }
}
