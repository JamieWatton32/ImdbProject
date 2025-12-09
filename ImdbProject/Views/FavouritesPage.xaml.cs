using System.Windows;
using System.Windows.Controls;

namespace ImdbProject.Views
{
    public partial class FavouritesPage : Page
    {
        public FavouritesPage()
        {
            InitializeComponent();
        }

        private void BackToTitles_Click(object sender, RoutedEventArgs e)
        {
            if (Application.Current.MainWindow is MainWindow mainWindow)
            {
                mainWindow.NavigateToTitleList();
            }
        }
    }
}
