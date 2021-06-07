using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace RTChatDiscordAndTelegram.ViewModels
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        public delegate TViewModel CreateViewModel<TViewModel>() where TViewModel : ViewModelBase;
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
