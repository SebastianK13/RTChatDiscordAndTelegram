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
    public partial class HomeView : UserControl
    {
        private readonly MainWindow _mainWindow;
        private bool _isMaximized = true;
        private Point _clickPoint;
        private double lastWindowTopPos = 0;
        private double lastWindowLeftPos = 0;
        private StackPanel topBorder;
        private StackPanel bottomBorder;
        private StackPanel leftBorder;
        private StackPanel rightBorder;
        private StackPanel topLeftBorder;
        private StackPanel topRightBorder;
        private double X;
        private double Y;
        private double actualHeight;
        private double actualWidth;
        public HomeView()
        {
            InitializeComponent();
            _mainWindow = (MainWindow)Application.Current.MainWindow;
            topBorder = (StackPanel)this.FindName("borderTop");
            bottomBorder = (StackPanel)this.FindName("borderBottom");
            leftBorder = (StackPanel)this.FindName("borderLeft");
            rightBorder = (StackPanel)this.FindName("borderRight");
            topLeftBorder = (StackPanel)this.FindName("borderTopLeft");
            topRightBorder = (StackPanel)this.FindName("borderTopRight");
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
                    SetCurrentWindowPostistion();
                }
            }
        }
        private void CenterWindow()
        {
            var currentScreen = MonitorDetails();
            double screenWidth = 800;
            double screenHeight = 450;
            if (_isMaximized)
            {
                screenWidth = currentScreen.Bounds.Width;
                screenHeight = currentScreen.Bounds.Height;
                _mainWindow.Left = currentScreen.Bounds.Left;
                _mainWindow.Top = currentScreen.Bounds.Top;
                HideBorder();
            }
            else
            {
                _mainWindow.Left = lastWindowLeftPos;
                _mainWindow.Top = lastWindowTopPos;
                ShowBorder();
            }
            _mainWindow.Width = screenWidth;
            _mainWindow.Height = screenHeight;
        }
        private System.Windows.Forms.Screen MonitorDetails() =>
            System.Windows.Forms.Screen.FromHandle(
            new System.Windows.Interop.WindowInteropHelper(_mainWindow).Handle);

        private void SetCurrentWindowPostistion()
        {
            lastWindowTopPos = _mainWindow.Top;
            lastWindowLeftPos = _mainWindow.Left;
        }       

        private void Border_MouseEnter(object sender, MouseEventArgs e)
        {

        }
        private void HideBorder()
        {
            topBorder.Background = new SolidColorBrush(Color.FromRgb(33, 35, 37));
            topBorder.Opacity = 1;
            topLeftBorder.Background = new SolidColorBrush(Color.FromRgb(33, 35, 37));
            topLeftBorder.Opacity = 1;
            topRightBorder.Background = new SolidColorBrush(Color.FromRgb(33, 35, 37));
            topRightBorder.Opacity = 1;
            bottomBorder.Background = new SolidColorBrush(Color.FromRgb(31, 38, 48));
            bottomBorder.Opacity = 1;
            leftBorder.Background = new SolidColorBrush(Color.FromRgb(31, 38, 48));
            leftBorder.Opacity = 1;
            rightBorder.Background = new SolidColorBrush(Color.FromRgb(31, 38, 48));
            rightBorder.Opacity = 1;
        }
        private void ShowBorder()
        {
            topBorder.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            topBorder.Opacity = .1;
            bottomBorder.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            bottomBorder.Opacity = .1;
            leftBorder.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            leftBorder.Opacity = .1;
            rightBorder.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            rightBorder.Opacity = .1;
            topLeftBorder.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            topLeftBorder.Opacity = .1;
            topRightBorder.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            topRightBorder.Opacity = .1;
        }

        private void DockPanelTop_MouseEnter(object sender, MouseEventArgs e)
        {
            if (!_isMaximized)
            {
                SetCurrentMousePos(e.GetPosition(this));
                if (X <= actualWidth && X >= actualWidth - 2)
                    _mainWindow.Cursor = Cursors.SizeNESW;
                else if (X >= 0 && X <= 2)
                    _mainWindow.Cursor = Cursors.SizeNWSE;
                else
                    _mainWindow.Cursor = Cursors.SizeNS;
            }
        }
        private void DockPanelBottom_MouseEnter(object sender, MouseEventArgs e)
        {
            if (!_isMaximized)
            {
                SetCurrentMousePos(e.GetPosition(this));
                if (X <= actualWidth && X >= actualWidth - 3)
                    _mainWindow.Cursor = Cursors.SizeNWSE;
                else if (X >= 0 && X <= 3)
                    _mainWindow.Cursor = Cursors.SizeNESW;
                else
                    _mainWindow.Cursor = Cursors.SizeNS;
            }
        }
        private void DockPanelLeft_MouseEnter(object sender, MouseEventArgs e)
        {
            if (!_isMaximized)
            {
                SetCurrentMousePos(e.GetPosition(this));
                if (Y <= actualHeight && Y >= actualHeight - 3)
                    _mainWindow.Cursor = Cursors.SizeNESW;
                else
                    _mainWindow.Cursor = Cursors.SizeWE;
            }
        }
        private void DockPanelRight_MouseEnter(object sender, MouseEventArgs e)
        {
            if (!_isMaximized)
            {
                SetCurrentMousePos(e.GetPosition(this));
                if (Y <= actualHeight && Y >= actualHeight - 3)
                    _mainWindow.Cursor = Cursors.SizeNWSE;
                else
                    _mainWindow.Cursor = Cursors.SizeWE;
            }
        }
        private void DockPanelLeftCorner_MouseEnter(object sender, MouseEventArgs e)
        {
            if (!_isMaximized)
            {
                SetCurrentMousePos(e.GetPosition(this));
                if (Y <= 0 && Y >= 3)
                    _mainWindow.Cursor = Cursors.SizeNESW;
                else
                    _mainWindow.Cursor = Cursors.SizeWE;
            }
        }
        private void DockPanelRightCorner_MouseEnter(object sender, MouseEventArgs e)
        {
            if (!_isMaximized)
            {
                SetCurrentMousePos(e.GetPosition(this));
                if (Y <= 0 && Y >= 3)
                    _mainWindow.Cursor = Cursors.SizeNWSE;
                else
                    _mainWindow.Cursor = Cursors.SizeWE;
            }
        }

        private void DockPanelTop_MouseLeave(object sender, MouseEventArgs e)
        {
            _mainWindow.Cursor = Cursors.Arrow;
        }
        private void DockPanelBottom_MouseLeave(object sender, MouseEventArgs e)
        {
            _mainWindow.Cursor = Cursors.Arrow;
        }
        private void DockPanelLeft_MouseLeave(object sender, MouseEventArgs e)
        {
            _mainWindow.Cursor = Cursors.Arrow;
        }
        private void DockPanelRight_MouseLeave(object sender, MouseEventArgs e)
        {
            _mainWindow.Cursor = Cursors.Arrow;
        }
        private void DockPanelLeftCorner_MouseLeave(object sender, MouseEventArgs e)
        {
            _mainWindow.Cursor = Cursors.Arrow;
        }
        private void DockPanelRightCorner_MouseLeave(object sender, MouseEventArgs e)
        {
            _mainWindow.Cursor = Cursors.Arrow;
        }
        private void SetCurrentMousePos(Point position)
        {
            Point currentPosition = position;
            X = currentPosition.X;
            Y = currentPosition.Y;
            actualHeight = _mainWindow.ActualHeight;
            actualWidth = _mainWindow.ActualWidth;
        }
    }
}
