using ImdbProject.Models;

namespace ImdbProject.Repositories.Interfaces
{
    public interface ITitleAliasRepository : IRepository<TitleAlias>
    {
        Task<TitleAlias?> GetTitleAliasAsync(string titleId, int ordering);
        Task<IEnumerable<TitleAlias>> GetByTitleIdAsync(string titleId);
    }
}