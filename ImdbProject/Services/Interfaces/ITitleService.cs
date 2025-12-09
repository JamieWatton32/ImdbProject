using ImdbProject.Models;

namespace ImdbProject.Services.Interfaces
{
    public interface ITitleService : IBaseService<Title>
    {
        public Task<Title?> GetTitleAsync(string titleId);
        public Task<List<Title>> GetTitlesWithEpisodesAsync();
    }
}