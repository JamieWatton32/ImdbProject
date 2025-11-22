using ImdbProject.Models;
using ImdbProject.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ImdbProject.Services.Episodes
{
    public class EpisodeService(EpisodeRepository repository) : BaseService<Episode>(repository)
    {
        private readonly EpisodeRepository _episodeRepository = repository;

        public async Task<Episode?> GetEpisodeAsync(string titleId)
        {
            return await _episodeRepository.GetEpisodeWithDetailsAsync(titleId);
        }
    }
}
