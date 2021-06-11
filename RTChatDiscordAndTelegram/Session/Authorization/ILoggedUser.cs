using System;
using System.Collections.Generic;
using System.Text;

namespace RTChatDiscordAndTelegram.Session.Authorization
{
    public interface ILoggedUser
    {
        string CurrentUser { get; set; }
        string UID { get; set; }
    }
}
