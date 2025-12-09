using System.Windows;
using System.Windows.Controls;

namespace ImdbProject.Views
{
    public partial class WelcomePage : Page
    {
        public WelcomePage()
        {
            InitializeComponent();
        }

        private void BrowseTitles_Click(object sender, RoutedEventArgs e)
        {
            if (Application.Current.MainWindow is MainWindow mainWindow)
            {
                mainWindow.NavigateToTitleList();
            }
        }

        private void ViewFavourites_Click(object sender, RoutedEventArgs e)
        {
            if (Application.Current.MainWindow is MainWindow mainWindow)
            {
                mainWindow.NavigateToFavourites();
            }
        }
    }
}
