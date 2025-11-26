using CommunityToolkit.Mvvm.ComponentModel;


namespace ImdbProject.ViewModels
{
    public partial class TitleDetailsViewModel : ObservableObject
    {
        private readonly MainViewModel _mainViewModel;

        [ObservableProperty]
        private TitleViewModel? _selectedTitle;

        public TitleDetailsViewModel(MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;
        }

        public async Task LoadTitleDetailsAsync(string titleId)
        {
            var title = _mainViewModel.Titles.FirstOrDefault(t => t.TitleId == titleId);
            if (title != null)
            {
                SelectedTitle = title;
            }
        }
    }
}
