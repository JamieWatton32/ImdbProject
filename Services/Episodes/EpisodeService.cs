using ImdbProject.Models;
using ImdbProject.Repositories.Interfaces;
using ImdbProject.Services.Interfaces;

namespace ImdbProject.Services.Episodes
{
    public class EpisodeService : BaseService<Episode>, IEpisodeService
    {
        private readonly IEpisodeRepository _episodeRepository;

        public EpisodeService(IEpisodeRepository episodeRepository) : base(episodeRepository)
        {
            _episodeRepository = episodeRepository;
        }

        public async Task<Episode?> GetEpisodeAsync(string titleId)
        {
            return await _episodeRepository.GetEpisodeWithDetailsAsync(titleId);
        }
    }
}
