using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ImdbProject.Models;
using ImdbProject.Services.Interfaces;


namespace ImdbProject.ViewModels
{
    public partial class TitleDetailsViewModel : ObservableObject
    {
        private readonly ITitleService _titleService;

        [ObservableProperty]
        private TitleViewModel? _selectedTitle;

        public event Action<string>? NavigateToNameDetails;
        public TitleDetailsViewModel(ITitleService titleService)
        {
            _titleService = titleService;
        }

        public async Task LoadTitleDetailsAsync(string titleId)
        {
            var title = await _titleService.GetTitleAsync(titleId);
            if (title != null)
            {
                SelectedTitle = TitleViewModel.FromModel(title);
            }
        }

        [RelayCommand]
        private void GoToNameDetails(string titleId)
        {
            NavigateToNameDetails?.Invoke(titleId);
        }
    }
}
