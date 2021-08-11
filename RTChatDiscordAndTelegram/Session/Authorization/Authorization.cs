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
        private readonly PasswordService _passwordService;

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
            _passwordService = new PasswordService();
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
                    if (result)
                    {
                        _loggedUser.UID = user.Username;
                        _loggedUser.UID = user.Id.ToString();
                        CurrentUsername = user.Username;
                        return true;
                    }
                }
            }
            return false;
        }

        public async Task<bool> SignUp(string username, string password)
        {
            Identity user = new Identity();
            if (CurrentUsername is null)
            {
                user = await _identityService.GetUserByName(username);
                    
                if (user == null) 
                {
                    string hash = _passwordService.HashPassword(password);
                    await _identityService.CreateNewUser(username, hash);
                    return true;
                }

            }
            return false;
        }
    }
}
