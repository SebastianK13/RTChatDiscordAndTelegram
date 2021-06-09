using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RTChatDiscordAndTelegram.Models;
using RTChatDiscordAndTelegram.Session.Factory;
using RTChatDiscordAndTelegram.Session.Navigation;
using RTChatDiscordAndTelegram.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using static RTChatDiscordAndTelegram.ViewModels.ViewModelBase;

namespace RTChatDiscordAndTelegram
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        private readonly IHost _host;
        public App() =>
            _host = CreateHostBuilder().Build();

        public static IHostBuilder CreateHostBuilder() =>
            Host.CreateDefaultBuilder(null)
            .ConfigureAppConfiguration(c =>
            {
                c.AddJsonFile("appsettings.json");
                c.AddEnvironmentVariables();
            })
            .ConfigureServices((context, services) =>
            {
                services.AddSingleton<CreateViewModel<HomeViewModel>>(service =>
                {
                    return () => new HomeViewModel(
                        service.GetRequiredService<IViewForwarding>(),
                        service.GetRequiredService<IViewModelFactory>());
                });
                services.AddSingleton<CreateViewModel<LoginViewModel>>(service =>
                {
                    return () => new LoginViewModel(
                        service.GetRequiredService<IViewForwarding>(),
                        service.GetRequiredService<IViewModelFactory>());
                });
                services.AddSingleton<CreateViewModel<DiscordViewModel>>(service =>
                {
                    return () => new DiscordViewModel(
                        service.GetRequiredService<IViewForwarding>(),
                        service.GetRequiredService<IViewModelFactory>());
                });
                services.AddSingleton<CreateViewModel<TelegramViewModel>>(service =>
                {
                    return () => new TelegramViewModel(
                        service.GetRequiredService<IViewForwarding>(),
                        service.GetRequiredService<IViewModelFactory>());
                });
                services.AddSingleton<CreateViewModel<SharedViewModel>>(service =>
                {
                    return () => new SharedViewModel(
                        service.GetRequiredService<IViewForwarding>(),
                        service.GetRequiredService<IViewModelFactory>());
                });
                services.AddSingleton<IViewModelFactory, ViewModelFactory>(c =>
                {
                    ViewModelsContainer interfaceContainer = new ViewModelsContainer()
                    {
                        CreateHomeVM = c.GetRequiredService<CreateViewModel<HomeViewModel>>(),
                        CreateDiscordVM = c.GetRequiredService<CreateViewModel<DiscordViewModel>>(),
                        CreateLoginVM = c.GetRequiredService<CreateViewModel<LoginViewModel>>(),
                        CreateSharedVM = c.GetRequiredService<CreateViewModel<SharedViewModel>>(),
                        CreateTelegramVM = c.GetRequiredService<CreateViewModel<TelegramViewModel>>()
                    };

                    return new ViewModelFactory(interfaceContainer);
                }
                );
                services.AddSingleton<IViewForwarding, ViewForwarding>();
                services.AddScoped<MainWindowViewModel>();
                services.AddScoped<MainWindow>(s => new MainWindow(s.GetRequiredService<MainWindowViewModel>()));
            });
        protected override void OnStartup(StartupEventArgs e)
        {
            _host.Start();

            Window window = _host.Services.GetRequiredService<MainWindow>();
            window.Show();

            base.OnStartup(e);

        }
        protected override async void OnExit(ExitEventArgs e)
        {
            await _host.StopAsync();
            _host.Dispose();

            base.OnExit(e);
        }
    }
}
