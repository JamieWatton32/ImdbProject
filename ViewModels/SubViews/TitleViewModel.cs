using CommunityToolkit.Mvvm.ComponentModel;
using ImdbProject.Models;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;

namespace ImdbProject.ViewModels
{
    /// <summary>
    /// ViewModel for a single Title entity.
    /// Represents ONE title with its properties.
    /// </summary>
    public partial class TitleViewModel : ObservableObject
    {
        [ObservableProperty]
        private string _titleId = null!;

        [ObservableProperty]
        private string? _titleType;

        [ObservableProperty]
        private string? _primaryTitle;

        [ObservableProperty]
        private string? _originalTitle;

        [ObservableProperty]
        private bool? _isAdult;

        [ObservableProperty]
        private short? _startYear;

        [ObservableProperty]
        private short? _endYear;

        [ObservableProperty]
        private short? _runtimeMinutes;

        // Navigation properties
        [ObservableProperty]
        private ObservableCollection<Genre> _genres = [];

        [ObservableProperty]
        private Rating? _rating;

        [ObservableProperty]
        private Episode? _episodeTitle;

        [ObservableProperty]
        private ObservableCollection<Episode> _episodes = [];

        [ObservableProperty]
        private ObservableCollection<TitleAlias> _titleAliases = [];

        [ObservableProperty]
        private ObservableCollection<Name> _directors = [];

        [ObservableProperty]
        private ObservableCollection<Name> _writers = [];

        [ObservableProperty]
        private ObservableCollection<Name> _knownFor = [];

        public static TitleViewModel FromModel(Title title)
        {
            return new TitleViewModel
            {
                TitleId = title.TitleId,
                TitleType = title.TitleType,
                PrimaryTitle = title.PrimaryTitle,
                OriginalTitle = title.OriginalTitle,
                IsAdult = title.IsAdult,
                StartYear = title.StartYear,
                EndYear = title.EndYear,
                RuntimeMinutes = title.RuntimeMinutes,
                Genres = new ObservableCollection<Genre>(title.Genres),
                Rating = title.Rating,
                EpisodeTitle = title.EpisodeTitle,
                Episodes = new ObservableCollection<Episode>(title.EpisodeParentTitles),
                TitleAliases = new ObservableCollection<TitleAlias>(title.TitleAliases),
                Directors = new ObservableCollection<Name>(title.Names),
                Writers = new ObservableCollection<Name>(title.Names1),
                KnownFor = new ObservableCollection<Name>(title.NamesNavigation)
            };
        }
    }
}