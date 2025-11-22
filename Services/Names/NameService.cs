using ImdbProject.Models;
using ImdbProject.Repositories;
using System.Threading.Tasks;

namespace ImdbProject.Services.Names
{
    public class NameService : BaseService<Name>
    {
        private readonly NameRepository _nameRepository;

        public NameService(NameRepository repository) : base(repository)
        {
            _nameRepository = repository;
        }

        public async Task<Name?> GetNameAsync(string nameId)
        {
            return await _nameRepository.GetNameWithDetailsAsync(nameId);
        }
    }
}