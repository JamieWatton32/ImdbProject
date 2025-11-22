using ImdbProject.Models;
using ImdbProject.Repositories;


namespace ImdbProject.Services.Genres
{
    public class GenreService : BaseService<Genre>
    {
        private readonly GenreRepository _genreRepository;

        public GenreService(GenreRepository repository) : base(repository)
        {
            _genreRepository = repository;
        }

      
    }
}
