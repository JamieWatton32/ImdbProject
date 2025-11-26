using ImdbProject.Models;
using ImdbProject.Repositories.Interfaces;
using ImdbProject.Services.Interfaces;

namespace ImdbProject.Services.Titles
{
    public class TitleService : BaseService<Title>, ITitleService
    {
        private readonly ITitleRepository _titleRepository;

        public TitleService(ITitleRepository repository) : base(repository)
        {
            _titleRepository = repository;
        }

        public Task<Title?> GetTitleAsync(string titleId)
        {
            return _titleRepository.GetTitleWithDetailsAsync(titleId);
        }

        public Task<List<Title>> GetTitlesWithEpisodesAsync()
        {
            return _titleRepository.GetTvSeries();
        }
    }
}