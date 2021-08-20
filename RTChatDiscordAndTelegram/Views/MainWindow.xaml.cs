using RTChatDiscordAndTelegram.ViewModels;
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
using System.Windows.Shapes;

namespace RTChatDiscordAndTelegram.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainWindowViewModel mWVM;
        private readonly LoginWindow loginWindow;
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
        private double lastHeight = 450;
        private double lastWidth = 800;
        private bool init = true;
        private bool block = true;
        public MainWindow(object parameter)
        {
            InitializeComponent();
            DataContext = parameter;
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            loginWindow = new LoginWindow(this);
            loginWindow.DataContext = parameter;
            loginWindow.Show();
            this.Hide();
            topBorder = (StackPanel)this.FindName("borderTop");
            bottomBorder = (StackPanel)this.FindName("borderBottom");
            leftBorder = (StackPanel)this.FindName("borderLeft");
            rightBorder = (StackPanel)this.FindName("borderRight");
            topLeftBorder = (StackPanel)this.FindName("borderTopLeft");
            topRightBorder = (StackPanel)this.FindName("borderTopRight");
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
            MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight - 10;
            MaxWidth = SystemParameters.MaximizedPrimaryScreenWidth - 10;
            this.Height = this.MaxHeight;
            this.Width = this.MaxWidth;
            this.Left = 0;
            this.Top = 0;
        }

        private void Window_StateChanged(object sender, EventArgs e)
        {
            if (this.WindowState == WindowState.Maximized)
            {
                _isMaximized = true;
                this.WindowState = WindowState.Normal;
                CenterWindow();
            }
        }

        private void ContentControl_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left && e.ClickCount == 2)
            {
                if (IsDockPanel(e.Source))
                    Maximize_Minimize();
            }
            _clickPoint = e.GetPosition(this);
        }

        private void Maximize_Minimize()
        {
            if (!_isMaximized)
            {
                _isMaximized = true;
                CenterWindow();
            }
            else
            {
                this.Height = lastHeight;
                this.Width = lastWidth;
                _isMaximized = false;
                CenterWindow();
            }
        }

        private bool IsDockPanel(object clickedObject)
        {
            DockPanel clickedObjectCasting = clickedObject as DockPanel;
            if (clickedObjectCasting != null)
            {
                if (clickedObjectCasting.Name == "MainBar")
                    return true;
            }

            return false;
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
                    if (_isMaximized)
                    {
                        this.Height = lastHeight;
                        this.Width = lastWidth;
                    }
                    _isMaximized = false;
                    this.DragMove();
                    if (!_isMaximized)
                        this.ResizeMode = ResizeMode.CanResizeWithGrip;
                    SetCurrentWindowPostistion();
                    block = false;
                }
            }
        }
        private void CenterWindow()
        {
            var currentScreen = MonitorDetails();
            double screenWidth = lastWidth;
            double screenHeight = lastHeight;
            if (_isMaximized)
            {
                screenWidth = currentScreen.Bounds.Width;
                screenHeight = currentScreen.Bounds.Height;
                this.Left = currentScreen.Bounds.Left;
                this.Top = currentScreen.Bounds.Top;
                this.ResizeMode = ResizeMode.NoResize;
                HideBorder();
            }
            else
            {
                this.Left = lastWindowLeftPos;
                this.Top = lastWindowTopPos;
                this.ResizeMode = ResizeMode.CanResizeWithGrip;
                ShowBorder();
            }
            this.Width = screenWidth;
            this.Height = screenHeight;
            block = false;
        }
        private System.Windows.Forms.Screen MonitorDetails() =>
            System.Windows.Forms.Screen.FromHandle(
            new System.Windows.Interop.WindowInteropHelper(this).Handle);

        private void SetCurrentWindowPostistion()
        {
            lastWindowTopPos = this.Top;
            lastWindowLeftPos = this.Left;
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

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (!block && !_isMaximized)
            {
                lastWidth = this.Width;
                lastHeight = this.Height;
            }
            else if (init)
            {
                lastWidth = 800;
                block = true;
                init = false;
            }
        }

        private void Button_Minimize(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void Button_Maximize(object sender, RoutedEventArgs e)
        {
            Maximize_Minimize();
        }

        private void Button_Close(object sender, RoutedEventArgs e) =>
            this.Close();

    }
}