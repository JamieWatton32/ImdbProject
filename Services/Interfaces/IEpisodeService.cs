using ImdbProject.Models;

namespace ImdbProject.Services.Interfaces
{
    public interface IEpisodeService : IBaseService<Episode>
    {
        public Task<Episode?> GetEpisodeAsync(string titleId);
    }
}