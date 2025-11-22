using CommunityToolkit.Mvvm.ComponentModel;
using ImdbProject.Models;

namespace ImdbProject.ViewModels
{
    /// <summary>
    /// ViewModel for a single Episode entity.
    /// Represents ONE episode with its properties.
    /// Does NOT contain services or collections - The parent view model handle those.
    /// </summary>
    public partial class EpisodeViewModel : ObservableObject
    {
        [ObservableProperty]
        private string _titleId = null!;

        [ObservableProperty]
        private string? _parentTitleId;

        [ObservableProperty]
        private int? _seasonNumber;

        [ObservableProperty]
        private int? _episodeNumber;

        [ObservableProperty]
        private Title? _parentTitle;

        [ObservableProperty]
        private Title _title = null!;

        /// <summary>
        /// Factory method to create an EpisodeViewModel from an Episode model
        /// </summary>
        public static EpisodeViewModel FromModel(Episode episode)
        {
            return new EpisodeViewModel
            {
                TitleId = episode.TitleId,
                ParentTitleId = episode.ParentTitleId,
                SeasonNumber = episode.SeasonNumber,
                EpisodeNumber = episode.EpisodeNumber,
                ParentTitle = episode.ParentTitle,
                Title = episode.Title
            };
        }
    }
}
