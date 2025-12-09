using ImdbProject.Models;

namespace ImdbProject.Repositories.Interfaces
{
    public interface ITitleRepository : IRepository<Title>
    {
        Task<Title?> GetTitleWithDetailsAsync(string titleId);
        Task<List<Title>> GetTvAndMovies();
    }
}