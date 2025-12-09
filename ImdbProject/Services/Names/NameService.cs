using ImdbProject.Models;
using ImdbProject.Repositories.Interfaces;
using ImdbProject.Services.Interfaces;

namespace ImdbProject.Services.Names
{
    public class NameService : BaseService<Name>, INameService
    {
        private readonly INameRepository _nameRepository;

        public NameService(INameRepository repository) : base(repository)
        {
            _nameRepository = repository;
        }

        public async Task<Name?> GetNameAsync(string nameId)
        {
            return await _nameRepository.GetNameWithDetailsAsync(nameId);
        }
    }
}