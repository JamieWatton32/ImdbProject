using ImdbProject.ViewModels;
using ImdbProject.Views;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows;

namespace ImdbProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly MainViewModel _mainViewModel;
        private readonly IServiceProvider _serviceProvider;

        public MainWindow(MainViewModel mainViewModel, IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _mainViewModel = mainViewModel;
            _serviceProvider = serviceProvider;
            DataContext = _mainViewModel;

            // Subscribe to navigation events
            _mainViewModel.NavigateToTitleDetails += OnNavigateToTitleDetails;
            
            NavigateToHome();
        }

        private void NavigateToHome()
        {
            var homePage = new HomePage
            {
                DataContext = _mainViewModel
            };
            MainFrame.Navigate(homePage);
        }

        private async void OnNavigateToTitleDetails(string titleId)
        {
            var titleDetailsViewModel = _serviceProvider.GetRequiredService<TitleDetailsViewModel>();
            
            await titleDetailsViewModel.LoadTitleDetailsAsync(titleId);

            var detailsPage = new TitleDetailsPage { DataContext = _mainViewModel };

            MainFrame.Navigate(detailsPage);
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigateToHome();
        }

        protected override void OnClosed(EventArgs e)
        {
            _mainViewModel.NavigateToTitleDetails -= OnNavigateToTitleDetails;
            base.OnClosed(e);
        }
    }
}