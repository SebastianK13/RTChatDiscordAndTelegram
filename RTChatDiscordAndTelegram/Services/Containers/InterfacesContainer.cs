using RTChatDiscordAndTelegram.Session.Authorization;
using RTChatDiscordAndTelegram.Session.Factory;
using RTChatDiscordAndTelegram.Session.Navigation;
using System;
using System.Collections.Generic;
using System.Text;

namespace RTChatDiscordAndTelegram.Services.Containers
{
    public class InterfacesContainer
    {
        public IViewForwarding Forwarding { get; set; }
        public IViewModelFactory ViewModelFactory { get; set; }
        public IAuthorization Authorization { get; set; }
        public ILoggedUser LoggedUser { get; set; }

    }
}
