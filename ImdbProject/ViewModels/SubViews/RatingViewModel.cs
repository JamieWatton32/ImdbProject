using CommunityToolkit.Mvvm.ComponentModel;
using ImdbProject.Models;

namespace ImdbProject.ViewModels
{
    /// <summary>
    /// ViewModel for a single Rating entity
    /// </summary>
    public partial class RatingViewModel : ObservableObject
    {
        [ObservableProperty]
        private string _titleId = null!;

        [ObservableProperty]
        private decimal? _averageRating;

        [ObservableProperty]
        private int? _numVotes;

        [ObservableProperty]
        private Title _title = null!;

        public static RatingViewModel FromModel(Rating rating)
        {
            return new RatingViewModel
            {
                TitleId = rating.TitleId,
                AverageRating = rating.AverageRating,
                NumVotes = rating.NumVotes,
                Title = rating.Title
            };
        }
    }
}
