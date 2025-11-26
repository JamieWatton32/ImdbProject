using System.Windows.Controls;

namespace ImdbProject.Views
{
    /// <summary>
    /// Interaction logic for TitleDetailsPage.xaml
    /// </summary>
    public partial class TitleDetailsPage : Page
    {
        public TitleDetailsPage()
        {
            InitializeComponent();
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
