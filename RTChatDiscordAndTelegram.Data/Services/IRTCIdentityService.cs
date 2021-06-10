using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RTChatDiscordAndTelegram.Data.Services
{
    public interface IRTCIdentityService
    {
        Task CreateNewUser(string username, string password);
        string GetHashPswd(string username);
    }
}
