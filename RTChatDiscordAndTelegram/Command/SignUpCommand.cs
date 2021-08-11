using RTChatDiscordAndTelegram.Data.Services;
using RTChatDiscordAndTelegram.Session.Authorization;
using RTChatDiscordAndTelegram.Session.Navigation;
using RTChatDiscordAndTelegram.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace RTChatDiscordAndTelegram.Command
{
    public class SignUpCommand : AsyncCommandBase
    {
        private readonly IAuthorization _authorization;
        private readonly IRTCIdentityService _identity;
        private readonly LoginViewModel _loginViewModel;

        public SignUpCommand(IRTCIdentityService identity,
            LoginViewModel loginViewModel, IAuthorization authorization)
        {
            _authorization = authorization;
            _identity = identity;
            _loginViewModel = loginViewModel;
        }


        public override async Task ExecuteAsync(object parameter)
        {
            PasswordBox passwordBox = parameter as PasswordBox;
            if (!String.IsNullOrWhiteSpace(_loginViewModel.Username) &&
                !String.IsNullOrWhiteSpace(passwordBox.Password))
            {
                bool result = await _authorization
                    .SignUp(_loginViewModel.Username, passwordBox.Password);

                if (result)
                {
                    _loginViewModel.UpdateViewModel.Execute(ViewName.HomeView);
                    _loginViewModel.ChangeLoginState(true);
                    _loginViewModel.ErrorVisibility = false;
                }
                else
                {
                    _loginViewModel.ErrorVisibility = true;
                    _loginViewModel.ErrorDesc = "Inserted username allready exist";
                }
            }
            else
            {
                _loginViewModel.ErrorVisibility = true;
                _loginViewModel.ErrorDesc = "Username and password cannot be empty";
            }
        }
    }
}
