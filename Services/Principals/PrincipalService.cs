using ImdbProject.Models;
using ImdbProject.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace ImdbProject.Services.Principals
{
    public class PrincipalService : BaseService<Principal>
    {
        private readonly PrincipalRepository _principalRepository;

        public PrincipalService(PrincipalRepository repository) : base(repository)
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
