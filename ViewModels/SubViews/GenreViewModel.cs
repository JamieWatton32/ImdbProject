using CommunityToolkit.Mvvm.ComponentModel;
using ImdbProject.Models;
using System.Collections.ObjectModel;

namespace ImdbProject.ViewModels
{
    /// <summary>
    /// ViewModel for a single Genre entity.
    /// </summary>
    public partial class GenreViewModel : ObservableObject
    {
        [ObservableProperty]
        private int _genreId;

        [ObservableProperty]
        private string _name = null!;

        [ObservableProperty]
        private ObservableCollection<Title> _titles = [];

        public static GenreViewModel FromModel(Genre genre)
        {
            return new GenreViewModel
            {
                GenreId = genre.GenreId,
                Name = genre.Name,
                Titles = new ObservableCollection<Title>(genre.Titles)
            };
        }
    }
}
