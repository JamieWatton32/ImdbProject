using CommunityToolkit.Mvvm.ComponentModel;
using ImdbProject.Models;
using System.Collections.ObjectModel;

namespace ImdbProject.ViewModels
{
    /// <summary>
    /// ViewModel for a single Name entity (actors, directors, writers, etc.)
    /// </summary>
    public partial class NameViewModel : ObservableObject
    {
        [ObservableProperty]
        private string _nameId = null!;

        [ObservableProperty]
        private string? _primaryName;

        [ObservableProperty]
        private int? _birthYear;

        [ObservableProperty]
        private int? _deathYear;

        [ObservableProperty]
        private string? _primaryProfession;

        [ObservableProperty]
        private ObservableCollection<Principal> _principals = [];

        [ObservableProperty]
        private ObservableCollection<Title> _directorTitles = [];

        [ObservableProperty]
        private ObservableCollection<Title> _writerTitles = [];

        [ObservableProperty]
        private ObservableCollection<Title> _knownForTitles = [];

        public static NameViewModel FromModel(Name name)
        {
            return new NameViewModel
            {
                NameId = name.NameId,
                PrimaryName = name.PrimaryName,
                BirthYear = name.BirthYear,
                DeathYear = name.DeathYear,
                PrimaryProfession = name.PrimaryProfession,
                Principals = new ObservableCollection<Principal>(name.Principals),
                DirectorTitles = new ObservableCollection<Title>(name.Titles),
                WriterTitles = new ObservableCollection<Title>(name.Titles1),
                KnownForTitles = new ObservableCollection<Title>(name.TitlesNavigation)
            };
        }
    }
}
