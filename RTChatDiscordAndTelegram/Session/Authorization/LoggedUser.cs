using System;
using System.Collections.Generic;
using System.Text;

namespace RTChatDiscordAndTelegram.Session.Authorization
{
    public class LoggedUser: ILoggedUser
    {
        public string CurrentUser { get; set; } 
        public string UID { get; set; }
    }
}
