using ImdbProject.Models;

namespace ImdbProject.Repositories.Interfaces
{
    public interface IEpisodeRepository : IRepository<Episode>
    {
        Task<Episode?> GetEpisodeWithDetailsAsync(string titleId);
    }
}