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

namespace RTChatDiscordAndTelegram
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainWindowViewModel mWVM;
        private readonly LoginWindow loginWindow;
        public MainWindow(object parameter)
        {
            InitializeComponent();
            DataContext = parameter;
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            loginWindow = new LoginWindow(this);
            loginWindow.DataContext = parameter;
            loginWindow.Show();
            //this.Hide();
        }
        private void Grid_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {

            if (mWVM.IsLogged())
            {
                loginWindow.Close();
                this.Show();
            }
        }
        
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            mWVM = (MainWindowViewModel)this.DataContext;
            mWVM.OnCloseDemand += (w, e) => loginWindow.Close();
            MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight-10;
            MaxWidth = SystemParameters.MaximizedPrimaryScreenWidth-10;
            this.Height = this.MaxHeight;
            this.Width = this.MaxWidth;
            this.Left = 0;
            this.Top = 0;
        }
    }
}
