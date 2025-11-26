using ImdbProject.Services;
using ImdbProject.ViewModels;
using Microsoft.Extensions.DependencyInjection;
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
            var services = new ServiceCollection();
            ConfigureServices(services);
            _serviceProvider = services.BuildServiceProvider();
        }

        private void ConfigureServices(IServiceCollection services)
        {
            services.AddImdbRepositories();
            services.AddImdbServices();
            services.AddSingleton<MainViewModel>();
            services.AddTransient<TitleDetailsViewModel>();
            services.AddTransient<MainWindow>();
            
            // Register IServiceProvider so it can be injected into MainWindow
            services.AddSingleton<IServiceProvider>(sp => sp);
        }

        private async void Application_Startup(object sender, StartupEventArgs e)
        {
            var mainViewModel = _serviceProvider.GetRequiredService<MainViewModel>();
            await mainViewModel.InitializeAsync();
            var mainWindow = _serviceProvider.GetRequiredService<MainWindow>();
            mainWindow.Show();
        }
    }
}
