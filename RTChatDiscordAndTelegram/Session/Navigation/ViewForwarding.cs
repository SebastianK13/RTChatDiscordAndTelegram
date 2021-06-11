using System;
using System.Collections.Generic;
using System.Text;
using RTChatDiscordAndTelegram.ViewModels;

namespace RTChatDiscordAndTelegram.Session.Navigation
{
    public class ViewForwarding : IViewForwarding
    {
        private ViewModelBase _activeViewModel;
        private ViewModelBase _activeViewLW;

        public ViewModelBase ActiveViewModel 
        {
            get => _activeViewModel;
            set 
            {
                _activeViewModel = value;
                StateChanged?.Invoke();
            } 
        }

        public ViewModelBase ActiveViewLW
        {
            get => _activeViewLW;
            set
            {
                _activeViewLW = value;
                StateChangedLW?.Invoke();
            }
        }

        public event Action StateChanged;
        public event Action StateChangedLW;
    }
}
