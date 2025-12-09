using ImdbProject.Models;

namespace ImdbProject.Services.Interfaces
{
    public interface INameService : IBaseService<Name>
    {
        Task<Name?> GetNameAsync(string nameId);
    }
}
