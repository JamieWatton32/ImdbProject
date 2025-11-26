using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ImdbProject.Models;
using ImdbProject.Services.Interfaces;
using System.Collections.ObjectModel;

namespace ImdbProject.ViewModels
{
    /// <summary>
    /// Place Holder ViewModel for the Main View
    /// </summary>
    /// 
    public partial class MainViewModel : ObservableObject
    {
        private readonly ITitleService _titleService;
        public ObservableCollection<TitleViewModel> Titles { get; }

        [ObservableProperty]
        private TitleViewModel? _selectedTitle;

        [ObservableProperty]
        private bool _isLoading;

        public event Action<string>? NavigateToTitleDetails;

        public MainViewModel(ITitleService titleService)
        {
            _titleService = titleService;
        
            Titles = [];

        }

        public async Task InitializeAsync()
        {
            IsLoading = true;
            await LoadTitlesAsync();
            IsLoading = false;
        }

        public async Task LoadTitlesAsync()
        {
            // TODO: THIS SHOULD LOAD MOVIES TOO BUT I NEED TO DEBUG IF EPISODES ARE LOADING PROPERLY FIRSTS
            var titles = await _titleService.GetTitlesWithEpisodesAsync();
            Titles.Clear();

            foreach (var title in titles)
            {
                Titles.Add(TitleViewModel.FromModel(title));
            }
        }

        [RelayCommand]
        private void GoToTitleDetails(string titleId)
        {
            NavigateToTitleDetails?.Invoke(titleId);
        }
    }
}
