using ImdbProject.Models;
using ImdbProject.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ImdbProject.Services.TitleAliases
{
    public class TitleAliasService : BaseService<TitleAlias>
    {
        private readonly TitleAliasRepository _titleAliasRepository;

        public TitleAliasService(TitleAliasRepository repository) : base(repository)
        {
            _titleAliasRepository = repository;
        }

        public async Task<TitleAlias?> GetTitleAliasAsync(string titleId, int ordering)
        {
            return await _titleAliasRepository.GetTitleAliasAsync(titleId, ordering);
        }

        public async Task<IEnumerable<TitleAlias>> GetByTitleIdAsync(string titleId)
        {
            return await _titleAliasRepository.GetByTitleIdAsync(titleId);
        }
    }
}
