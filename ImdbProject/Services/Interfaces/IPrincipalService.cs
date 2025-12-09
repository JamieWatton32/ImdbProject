using ImdbProject.Models;

namespace ImdbProject.Services.Interfaces
{
    public interface IPrincipalService : IBaseService<Principal>
    {
        Task<Principal?> GetPrincipalAsync(string titleId, int ordering);
        Task<IEnumerable<Principal>> GetByTitleIdAsync(string titleId);
    }
}
