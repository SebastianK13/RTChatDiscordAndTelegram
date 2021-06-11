using RTChatDiscordAndTelegram.Data.Models;
using RTChatDiscordAndTelegram.Data.Services;
using RTChatDiscordAndTelegram.Services.Crypto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RTChatDiscordAndTelegram.Session.Authorization
{
    public class Authorization: IAuthorization
    {
        private readonly IRTCIdentityService _identityService;
        private readonly ILoggedUser _loggedUser;

        public string CurrentUsername
        {
            get
            {
                return _loggedUser.CurrentUser;
            }
            set
            {
                _loggedUser.CurrentUser = value;
                StateChanged?.Invoke();
            }
        }
        public bool IsLogged => CurrentUsername != null;

        public event Action StateChanged;

        public Authorization(IRTCIdentityService identityService, ILoggedUser loggedUser)
        {
            _identityService = identityService;
            _loggedUser = loggedUser;
        }
        public async Task<bool> Login(string username, string password)
        {
            Identity user = new Identity();
            if (CurrentUsername is null)
            {
                user = await _identityService.GetUserByName(username);

                if (user != null)
                {
                    PasswordService passwordService = new PasswordService();
                    var result = passwordService.CompareHashes(user.PasswordHash, password);
                    if (!result)
                    {
                        return false;
                    }
                    else
                    {
                        _loggedUser.UID = user.Username;
                        _loggedUser.UID = user.Id.ToString();
                    }
                }
            }
            return true;
        }
    }
}
