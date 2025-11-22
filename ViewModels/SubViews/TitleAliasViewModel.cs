using CommunityToolkit.Mvvm.ComponentModel;
using ImdbProject.Models;

namespace ImdbProject.ViewModels
{
    /// <summary>
    /// ViewModel for a single TitleAlias entity (alternative titles in different regions/languages)
    /// </summary>
    public partial class TitleAliasViewModel : ObservableObject
    {
        [ObservableProperty]
        private string _titleId = null!;

        [ObservableProperty]
        private int _ordering;

        [ObservableProperty]
        private string _title = null!;

        [ObservableProperty]
        private string? _region;

        [ObservableProperty]
        private string? _language;

        [ObservableProperty]
        private bool? _isOriginalTitle;

        // Navigation property
        [ObservableProperty]
        private Title _titleNavigation = null!;

        public static TitleAliasViewModel FromModel(TitleAlias alias)
        {
            return new TitleAliasViewModel
            {
                TitleId = alias.TitleId,
                Ordering = alias.Ordering,
                Title = alias.Title,
                Region = alias.Region,
                Language = alias.Language,
                IsOriginalTitle = alias.IsOriginalTitle,
                TitleNavigation = alias.TitleNavigation
            };
        }
    }
}
