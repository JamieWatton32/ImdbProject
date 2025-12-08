using ImdbProject.ViewModels;
using System.Windows.Controls;
using Microsoft.Extensions.DependencyInjection;

namespace ImdbProject.Views
{
    /// <summary>
    /// Interaction logic for TitleDetailsPage.xaml
    /// </summary>
    public partial class TitleDetailsPage : Page
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly TitleDetailsViewModel _viewModel;
        public TitleDetailsPage(IServiceProvider serviceProvider, TitleDetailsViewModel viewModel)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
            _viewModel = viewModel;
            DataContext = _viewModel;


            _viewModel.NavigateToNameDetails += OnNavigateToNameDetails;
        }

        private void BackButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (NavigationService?.CanGoBack == true)
            {
                NavigationService.GoBack();
            }
        }

        private async void OnNavigateToNameDetails(string titleId)
        {
            var nameDetailsViewModel = _serviceProvider.GetRequiredService<NameDetailViewModel>();

            await nameDetailsViewModel.LoadNameDetailsAsync(titleId);

            var detailsPage = new NameDetailPage(nameDetailsViewModel);

            NavigationService?.Navigate(detailsPage);
        }
    }
}
