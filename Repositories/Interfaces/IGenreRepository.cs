using ImdbProject.Models;

namespace ImdbProject.Repositories.Interfaces
{
    public interface IGenreRepository : IRepository<Genre>
    {
        public Task<Genre?> GetGenreByNameAsync(string name);
        public Task<Genre?> GetGenreAsync(int genreId);
    }
}
