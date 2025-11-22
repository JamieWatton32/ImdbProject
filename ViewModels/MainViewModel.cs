using CommunityToolkit.Mvvm.ComponentModel;
using ImdbProject.Services.Episodes;
using ImdbProject.Services.Genres;
using ImdbProject.Services.Names;
using ImdbProject.Services.Principals;
using ImdbProject.Services.Ratings;
using ImdbProject.Services.TitleAliases;
using ImdbProject.Services.Titles;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ImdbProject.ViewModels
{
    /// <summary>
    /// Main ViewModel managing the overall state and data for the application.
    /// Other pages can access this ViewModel to access data via dependency injection.
    /// </summary>
    public partial class MainViewModel : ObservableObject
    {

        private readonly EpisodeService _episodeService;
        private readonly GenreService _genreService;
        private readonly TitleService _titleService;
        private readonly NameService _nameService;
        private readonly PrincipalService _principalService;
        private readonly RatingService _ratingService;
        private readonly TitleAliasService _titleAliasService;

        public ObservableCollection<EpisodeViewModel> Episodes { get; }
        public ObservableCollection<TitleViewModel> Titles { get; }
        public ObservableCollection<GenreViewModel> Genres { get; }
        public ObservableCollection<NameViewModel> Names { get; }
        public ObservableCollection<PrincipalViewModel> Principals { get; }
        public ObservableCollection<RatingViewModel> Ratings { get; }
        public ObservableCollection<TitleAliasViewModel> TitleAliases { get; }

        [ObservableProperty]
        private EpisodeViewModel? _selectedEpisode;

        [ObservableProperty]
        private TitleViewModel? _selectedTitle;

        [ObservableProperty]
        private GenreViewModel? _selectedGenre;

        [ObservableProperty]
        private NameViewModel? _selectedName;

        [ObservableProperty]
        private bool _isLoading;

        public MainViewModel(
            EpisodeService episodeService,
            GenreService genreService,
            TitleService titleService,
            NameService nameService,
            PrincipalService principalService,
            RatingService ratingService,
            TitleAliasService titleAliasService)
        {
            _episodeService = episodeService;
            _genreService = genreService;
            _titleService = titleService;
            _nameService = nameService;
            _principalService = principalService;
            _ratingService = ratingService;
            _titleAliasService = titleAliasService;

            // Initialize collections
            Episodes = [];
            Titles = [];
            Genres = [];
            Names = [];
            Principals = [];
            Ratings = [];
            TitleAliases = [];
        }

        public async Task InitializeAsync()
        {
            IsLoading = true;

            await Task.WhenAll(
                LoadEpisodesAsync(),
                LoadTitlesAsync(),
                LoadGenresAsync(),
                LoadNamesAsync(),
                LoadPrincipalsAsync(),
                LoadRatingsAsync(),
                LoadTitleAliasesAsync()
            );

            IsLoading = false;
        }

        public async Task LoadEpisodesAsync()
        {
            var episodes = await _episodeService.GetAllAsync();
            Episodes.Clear();

            foreach (var episode in episodes)
            {
                Episodes.Add(EpisodeViewModel.FromModel(episode));
            }
        }

        public async Task LoadTitlesAsync()
        {
            var titles = await _titleService.GetAllAsync();
            Titles.Clear();

            foreach (var title in titles)
            {
                Titles.Add(TitleViewModel.FromModel(title));
            }
        }

        public async Task LoadGenresAsync()
        {
            var genres = await _genreService.GetAllAsync();
            Genres.Clear();

            foreach (var genre in genres)
            {
                Genres.Add(GenreViewModel.FromModel(genre));
            }
        }

        public async Task LoadNamesAsync()
        {
            var names = await _nameService.GetAllAsync();
            Names.Clear();

            foreach (var name in names)
            {
                Names.Add(NameViewModel.FromModel(name));
            }
        }

        public async Task LoadPrincipalsAsync()
        {
            var principals = await _principalService.GetAllAsync();
            Principals.Clear();

            foreach (var principal in principals)
            {
                Principals.Add(PrincipalViewModel.FromModel(principal));
            }
        }
        public async Task LoadRatingsAsync()
        {
            var ratings = await _ratingService.GetAllAsync();
            Ratings.Clear();

            foreach (var rating in ratings)
            {
                Ratings.Add(RatingViewModel.FromModel(rating));
            }
        }

        public async Task LoadTitleAliasesAsync()
        {
            var aliases = await _titleAliasService.GetAllAsync();
            TitleAliases.Clear();

            foreach (var alias in aliases)
            {
                TitleAliases.Add(TitleAliasViewModel.FromModel(alias));
            }
        }

        public async Task LoadTitleDetailsAsync(string titleId)
        {
            IsLoading = true;

            var title = await _titleService.GetTitleAsync(titleId);
            if (title != null)
            {
                SelectedTitle = TitleViewModel.FromModel(title);
            }

            var rating = await _ratingService.GetRatingAsync(titleId);
            if (rating != null && !Ratings.Any(r => r.TitleId == titleId))
            {
                Ratings.Add(RatingViewModel.FromModel(rating));
            }

            var principals = await _principalService.GetByTitleIdAsync(titleId);
            foreach (var principal in principals.Where(p => !Principals.Any(pr => pr.TitleId == p.TitleId && pr.Ordering == p.Ordering)))
            {
                Principals.Add(PrincipalViewModel.FromModel(principal));
            }

            var aliases = await _titleAliasService.GetByTitleIdAsync(titleId);
            foreach (var alias in aliases.Where(a => !TitleAliases.Any(ta => ta.TitleId == a.TitleId && ta.Ordering == a.Ordering)))
            {
                TitleAliases.Add(TitleAliasViewModel.FromModel(alias));
            }

            IsLoading = false;
        }

        public async Task LoadNameDetailsAsync(string nameId)
        {
            IsLoading = true;

            var name = await _nameService.GetNameAsync(nameId);
            if (name != null)
            {
                SelectedName = NameViewModel.FromModel(name);
            }

            IsLoading = false;
        }
    }
}
