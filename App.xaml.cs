using ImdbProject.Services;
using ImdbProject.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows;

namespace ImdbProject
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private IServiceProvider _serviceProvider;

        public App()
        {
            // Configure dependency injection container
            var services = new ServiceCollection();
            ConfigureServices(services);
            _serviceProvider = services.BuildServiceProvider();
        }

        private void ConfigureServices(IServiceCollection services)
        {
            // Register repositories and services using extension methods
            services.AddImdbRepositories();
            services.AddImdbServices();

            // Register MainViewModel as Singleton
            // MainViewModel holds all services and manages all collections
            services.AddSingleton<MainViewModel>();

            // Register MainWindow as Transient
            services.AddTransient<MainWindow>();
        }

        private async void Application_Startup(object sender, StartupEventArgs e)
        {
            // Resolve MainWindow from DI container
            var mainWindow = _serviceProvider.GetRequiredService<MainWindow>();
            
            // Resolve MainViewModel (same instance every time due to Singleton)
            var mainViewModel = _serviceProvider.GetRequiredService<MainViewModel>();
            
            // Load episodes (or use InitializeAsync() to load everything)
            await mainViewModel.LoadEpisodesAsync();
            
            mainWindow.DataContext = mainViewModel;
            mainWindow.Show();
        }
    }
}
