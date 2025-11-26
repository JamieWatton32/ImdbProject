using ImdbProject.Models;

namespace ImdbProject.Repositories.Interfaces
{
    public interface INameRepository : IRepository<Name>
    {
        Task<Name?> GetNameWithDetailsAsync(string nameId);
    }
}
