using ImdbProject.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;

namespace ImdbProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly MainViewModel _mainViewModel;
        private readonly TitleDetailsViewModel _titleDetailsViewModel;

        public MainWindow(MainViewModel mainViewModel, TitleDetailsViewModel titleDetailsViewModel)
        {
            InitializeComponent();
            _mainViewModel = mainViewModel;
            _titleDetailsViewModel = titleDetailsViewModel;
            DataContext = _mainViewModel;

        }
    }
}