using ImdbProject.Models;
using ImdbProject.Repositories.Interfaces;
using ImdbProject.Services.Interfaces;


namespace ImdbProject.Services.Principals
{
    public class PrincipalService : BaseService<Principal>, IPrincipalService
    {
        private readonly IPrincipalRepository _principalRepository;

        public PrincipalService(IPrincipalRepository repository) : base(repository)
        {
            _principalRepository = repository;
        }

        public async Task<Principal?> GetPrincipalAsync(string titleId, int ordering)
        {
            return await _principalRepository.GetPrincipalAsync(titleId, ordering);
        }

        public async Task<IEnumerable<Principal>> GetByTitleIdAsync(string titleId)
        {
            return await _principalRepository.GetByTitleIdAsync(titleId);
        }
    }
}
