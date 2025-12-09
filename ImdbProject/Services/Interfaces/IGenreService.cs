using ImdbProject.Models;

namespace ImdbProject.Services.Interfaces
{
    public interface IGenreService : IBaseService<Genre>
    {
        public Task<Genre?> GetGenreAsync(string genreId);
    }
}
