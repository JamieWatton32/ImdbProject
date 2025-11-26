using ImdbProject.Models;

namespace ImdbProject.Repositories.Interfaces
{
    public interface IPrincipalRepository : IRepository<Principal>
    {
        Task<Principal?> GetPrincipalAsync(string titleId, int ordering);
        Task<IEnumerable<Principal>> GetByTitleIdAsync(string titleId);
    }
}
