using System;
using System.Collections.Generic;
using System.Text;
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
    /// <summary>
    /// Interaction logic for HomeView.xaml
    /// </summary>
    public partial class HomeView : UserControl
    {
        private readonly MainWindow _mainWindow;
        private bool _isMaximized = true;
        private Point _clickPoint;
        public HomeView()
        {
            InitializeComponent();
            _mainWindow = (MainWindow)Application.Current.MainWindow;
        }

        private void ContentControl_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left && e.ClickCount == 2)
            {
                if (!_isMaximized)
                {
                    _isMaximized = true;
                    CenterWindow();
                }
                else
                {
                    _isMaximized = false;
                    _mainWindow.Height = 450;
                    _mainWindow.Width = 800;
                    CenterWindow();
                }

            }
            _clickPoint = e.GetPosition(this);
        }

        private void ContentControl_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                Point currentPosition = e.GetPosition(this);
                double distanceX = Math.Abs(_clickPoint.X - currentPosition.X);
                double distanceY = Math.Abs(_clickPoint.Y - currentPosition.Y);
                if (distanceX > 5 || distanceY > 5)
                {
                    _mainWindow.Height = 450;
                    _mainWindow.Width = 800;
                    _isMaximized = false;
                    _mainWindow.DragMove();
                }
            }
        }
        private void CenterWindow()
        {
            double screenWidth = 800;
            double screenHeight = 450;
            if (_isMaximized)
            {
                screenWidth = SystemParameters.PrimaryScreenWidth;
                screenHeight = SystemParameters.PrimaryScreenHeight;
            }
            _mainWindow.Width = screenWidth;
            _mainWindow.Height = screenHeight;
            _mainWindow.Left = 0;
            _mainWindow.Top = 0;
        }
    }
}
