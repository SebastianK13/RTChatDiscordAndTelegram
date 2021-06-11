using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using RTChatDiscordAndTelegram.Data.Services;
using RTChatDiscordAndTelegram.Session.Authorization;
using RTChatDiscordAndTelegram.Session.Navigation;
using RTChatDiscordAndTelegram.ViewModels;

namespace RTChatDiscordAndTelegram.Command
{
    public class LoginCommand : AsyncCommandBase
    {
        private readonly IRTCIdentityService _identity;
        private readonly IAuthorization _authorization;
        private readonly LoginViewModel _loginViewModel;

        public LoginCommand(IRTCIdentityService identity,
            LoginViewModel loginViewModel, IAuthorization authorization)
        {
            _authorization = authorization;
            _identity = identity;
            _loginViewModel = loginViewModel;
        }


        public override async Task ExecuteAsync(object parameter)
        {
            PasswordBox passwordBox = parameter as PasswordBox;
            bool result = await _authorization
                .Login(_loginViewModel.Username, passwordBox.Password);

            if (result)
            {
                _loginViewModel.UpdateViewModel.Execute(ViewName.HomeView);
                _loginViewModel.ErrorVisibility = false;
            }
            else
                _loginViewModel.ErrorVisibility = true;
        }
    }
}
