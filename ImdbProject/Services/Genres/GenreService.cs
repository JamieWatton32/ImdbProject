using ImdbProject.Models;
using ImdbProject.Repositories.Interfaces;
using ImdbProject.Services.Interfaces;

namespace ImdbProject.Services.Genres
{
    public class GenreService : BaseService<Genre>, IGenreService
    {
        private readonly IGenreRepository _genreRepository;

        public GenreService(IGenreRepository repository) : base(repository)
        {
            _genreRepository = repository;
        }
        public Task<Genre?> GetGenreAsync(int genreId)
        {
            return _genreRepository.GetGenreAsync(genreId);
        }

        public Task<Genre?> GetGenreAsync(string genreId)
        {
            return _genreRepository.GetGenreByNameAsync(genreId);
        }
    }
}
