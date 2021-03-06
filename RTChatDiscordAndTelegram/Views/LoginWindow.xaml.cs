using RTChatDiscordAndTelegram.Session.Navigation;
using RTChatDiscordAndTelegram.ViewModels;
using RTChatDiscordAndTelegram.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RTChatDiscordAndTelegram.Views
{
    public partial class LoginWindow : Window
    {
        private readonly MainWindow _mainWindow;
        private MainWindowViewModel main;
        public LoginWindow(MainWindow mainWindow)
        {
            _mainWindow = mainWindow;
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            main = (MainWindowViewModel)this.DataContext;
            if (!main.IsLogged())
                _mainWindow.Close();
            else
                _mainWindow.Show();
        }

    }
}
