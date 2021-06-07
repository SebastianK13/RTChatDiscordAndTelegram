using System;
using System.Collections.Generic;
using System.Text;
using RTChatDiscordAndTelegram.ViewModels;

namespace RTChatDiscordAndTelegram.Session.Navigation
{
    public class ViewForwarding : IViewForwarding
    {
        private ViewModelBase _activeViewModel;

        public ViewModelBase ActiveViewModel 
        {
            get => _activeViewModel;
            set 
            {
                _activeViewModel = value;
                StateChanged?.Invoke();
            } 
        }

        public event Action StateChanged;
    }
}
