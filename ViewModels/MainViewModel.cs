using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ImdbProject.Services.Interfaces;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace ImdbProject.ViewModels {
    /// <summary>
    /// Place Holder ViewModel for the Main View
    /// </summary>
    /// 
    public partial class MainViewModel : ObservableObject {
        private readonly ITitleService _titleService;

        /// <summary>
        /// All titles loaded from the database (unfiltered).
        /// </summary>
        private ObservableCollection<TitleViewModel> _allTitles;

        /// <summary>
        /// Filtered titles displayed in the DataGrid.
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

        [ObservableProperty]
        private string _searchText = string.Empty;

        public event Action<string>? NavigateToTitleDetails;

        public MainViewModel(ITitleService titleService) {
            _titleService = titleService;

            _allTitles = [];
            Titles = [];
            FavouriteTitles = [];
        }

        partial void OnSearchTextChanged(string value) {
            FilterTitles();
        }

        private void FilterTitles() {
            Titles.Clear();

            if (string.IsNullOrWhiteSpace(SearchText)) {
                // No search text - show all titles
                foreach (var title in _allTitles) {
                    Titles.Add(title);
                }
            }
            else {
                // Filter titles using LINQ
                var searchLower = SearchText.ToLower();

                var filtered = _allTitles.Where(t =>
                    (t.PrimaryTitle?.ToLower().Contains(searchLower) ?? false) ||
                    (t.OriginalTitle?.ToLower().Contains(searchLower) ?? false) ||
                    (t.TitleId?.ToLower().Contains(searchLower) ?? false)
                ).ToList();

                foreach (var title in filtered) {
                    Titles.Add(title);
                }
            }
        }

        public async Task InitializeAsync() {
            IsLoading = true;
            await LoadTitlesAsync();
            IsLoading = false;
        }

        public async Task LoadTitlesAsync() {
            _allTitles.Clear();
            Titles.Clear();
            FavouriteTitles.Clear();

            var titles = await _titleService.GetTitlesWithEpisodesAsync();

            foreach (var title in titles) {
                var vm = TitleViewModel.FromModel(title);
                _allTitles.Add(vm);
            }

            // Initial display - show all titles
            FilterTitles();
        }

        [RelayCommand]
        private void GoToTitleDetails(string titleId) {
            NavigateToTitleDetails?.Invoke(titleId);
        }

        /// <summary>
        /// Toggle the favourite state of a given title and keep FavouriteTitles in sync.
        /// </summary>
        [RelayCommand]
        private void ToggleFavourite(TitleViewModel? title) {
            if (title is null)
                return;

            // Flip the boolean on the row ViewModel
            title.IsFavourite = !title.IsFavourite;

            if (title.IsFavourite) {
                if (!FavouriteTitles.Contains(title)) {
                    FavouriteTitles.Add(title);
                }
            }
            else {
                if (FavouriteTitles.Contains(title)) {
                    FavouriteTitles.Remove(title);
                }
            }
        }
    }
}