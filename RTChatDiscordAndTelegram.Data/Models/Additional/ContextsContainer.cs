using RTChatDiscordAndTelegram.Data.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace RTChatDiscordAndTelegram.Data.Models.Additional
{
    public class ContextsContainer
    {
        public IRTCIdentityService Identity { get; set; }
    }
}
