using RTChatDiscordAndTelegram.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RTChatDiscordAndTelegram.Session.Authorization
{
    public interface IAuthorization
    {
        bool IsLogged { get; }

        Task<bool> Login(string username, string password);
        Task<bool> SignUp(string username, string password);
    }
}
