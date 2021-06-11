using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using RTChatDiscordAndTelegram.Data.Models;

namespace RTChatDiscordAndTelegram.Data.Services
{
    public interface IRTCIdentityService
    {
        Task CreateNewUser(string username, string password);
        Task<Identity> GetUserByName(string username);
    }
}
