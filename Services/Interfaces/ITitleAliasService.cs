using ImdbProject.Models;

namespace ImdbProject.Services.Interfaces
{
    public interface ITitleAliasService : IBaseService<TitleAlias>
    {
        Task<TitleAlias?> GetTitleAliasAsync(string titleId, int ordering);
        Task<IEnumerable<TitleAlias>> GetByTitleIdAsync(string titleId);
    }
}