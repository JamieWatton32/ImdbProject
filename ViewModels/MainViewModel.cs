using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ImdbProject.Services.Interfaces;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace ImdbProject.ViewModels
{
    /// <summary>
    /// Place Holder ViewModel for the Main View
    /// </summary>
    /// 
    public partial class MainViewModel : ObservableObject
    {
        private readonly ITitleService _titleService;

        /// <summary>
        /// All titles loaded from the database.
        /// </summary>
        public ObservableCollection<TitleViewModel> Titles { get; }

        /// <summary>
        /// Titles that are currently marked as favourites.
        /// </summary>
        public ObservableCollection<TitleViewModel> FavouriteTitles { get; }

        [ObservableProperty]
        private TitleViewModel? _selectedTitle;

        [ObservableProperty]
        private bool _isLoading;

        public event Action<string>? NavigateToTitleDetails;

        public MainViewModel(ITitleService titleService)
        {
            _titleService = titleService;
        
            Titles = [];
            FavouriteTitles = [];
        }

        public async Task InitializeAsync()
        {
            IsLoading = true;
            await LoadTitlesAsync();
            IsLoading = false;
        }

        public async Task LoadTitlesAsync()
        {
            Titles.Clear();
            FavouriteTitles.Clear();

            var titles = await _titleService.GetTitlesWithEpisodesAsync();

            foreach (var title in titles)
            {
                var vm = TitleViewModel.FromModel(title);
                Titles.Add(vm);
            }
        }

        [RelayCommand]
        private void GoToTitleDetails(string titleId)
        {
            NavigateToTitleDetails?.Invoke(titleId);
        }

        /// <summary>
        /// Toggle the favourite state of a given title and keep FavouriteTitles in sync.
        /// </summary>
        [RelayCommand]
        private void ToggleFavourite(TitleViewModel? title)
        {
            if (title is null)
                return;

            // Flip the boolean on the row ViewModel
            title.IsFavourite = !title.IsFavourite;

            if (title.IsFavourite)
            {
                if (!FavouriteTitles.Contains(title))
                {
                    FavouriteTitles.Add(title);
                }
            }
            else
            {
                if (FavouriteTitles.Contains(title))
                {
                    FavouriteTitles.Remove(title);
                }
            }
        }
    }
}
