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

            NavigateToWelcome();
        }

        /// <summary>
        /// Navigate to the landing / welcome screen.
        /// </summary>
        private void NavigateToWelcome()
        {
            var welcomePage = new WelcomePage();
            MainFrame.Navigate(welcomePage);
        }

        /// <summary>
        /// Navigate to the main title list page.
        /// </summary>
        public void NavigateToTitleList()
        {
            var titleListPage = new TitleListPage
            {
                DataContext = _mainViewModel
            };
            MainFrame.Navigate(titleListPage);
        }

        /// <summary>
        /// Navigate to the favourites page.
        /// </summary>
        public void NavigateToFavourites()
        {
            var favouritesPage = new FavouritesPage
            {
                DataContext = _mainViewModel
            };
            MainFrame.Navigate(favouritesPage);
        }

        private async void OnNavigateToTitleDetails(string titleId)
        {
            var titleDetailsViewModel = _serviceProvider.GetRequiredService<TitleDetailsViewModel>();
            
            await titleDetailsViewModel.LoadTitleDetailsAsync(titleId);

            var detailsPage = new TitleDetailsPage(_serviceProvider, titleDetailsViewModel);

            MainFrame.Navigate(detailsPage);
        }

        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            NavigateToWelcome();
        }

        private void TitlesButton_Click(object sender, RoutedEventArgs e)
        {
            NavigateToTitleList();
        }

        private void FavouritesButton_Click(object sender, RoutedEventArgs e)
        {
            NavigateToFavourites();
        }

        protected override void OnClosed(EventArgs e)
        {
            _mainViewModel.NavigateToTitleDetails -= OnNavigateToTitleDetails;
            base.OnClosed(e);
        }
    }
}