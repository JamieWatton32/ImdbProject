using ImdbProject.ViewModels;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace ImdbProject.Views
{
    /// <summary>
    /// Interaction logic for NameDetailPage.xaml
    /// </summary>
    public partial class NameDetailPage : Page
    {
        private readonly NameDetailViewModel _viewModel;
        public NameDetailPage(NameDetailViewModel viewModel)
        {
            InitializeComponent();
            _viewModel = viewModel;
            DataContext = _viewModel;
        }

        private void BackButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (NavigationService?.CanGoBack == true)
            {
                NavigationService.GoBack();
            }
        }
    }
}
